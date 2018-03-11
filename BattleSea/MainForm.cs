using BattleSea.Properties;
using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleSea
{
	public partial class MainForm : Form
	{
		private Game _game;
		private EditableField _editableField;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			InitFields();
			tbGameMode.SelectedIndex = 1;
			_game = new Game(Common.FieldSize);
			_game.OnEnemyShot += Game_OnEnemyShot;
			_editableField = new EditableField(dgvMy);
		}

		private void Game_OnEnemyShot(object sender, ShotResultEvent e)
		{
			dgvMy.Invoke(new Action(() => 
			{
				var res = e.Result;
				var p = Common.DeNormalizeCoordinates(e.X, e.Y);
				var cell = dgvMy.Rows[p.Y].Cells[p.X];
				string msg = string.Empty;
				switch (res.ResultType)
				{
					case ShotResultType.Missed:
						cell.Value = Resources.Missed;
						msg = "Hooray! Loser has missed. Let's answer them!";
						break;
					case ShotResultType.Fired:
						cell.Value = Resources.Fired;
						msg = "Sh#t! We caught fire!";
						break;
					case ShotResultType.Killed:
						DrawKilledShip(res);
						msg = "F#ck! We lost our ship!";
						if (!res.StillAlive)
						{
							msg += "\nGame is over. It was our last chance :(";
							DisposeGame();
						}
						break;
					default:
						throw new ApplicationException("Unknown result type");
				}
				tbMessages.AppendText(msg + "\n");
			}));
		}

		private void DrawKilledShip(ShotResult result)
		{
			foreach (var pos in result.KilledSegments.Select(seg => seg.Position))
			{
				var p = Common.DeNormalizeCoordinates(pos);
				dgvMy.Rows[p.Y].Cells[p.X].Value = Resources.Killed;
			}
		}

		private void RenderMyField()
		{
			IEnumerable<Point> points = null;
			if (_editableField.Enabled)
				points = _game.FieldGenerator.Ships
					.SelectMany(s=>s.Segments)
					.Select(seg=>seg.Position);
			else
				points = _game.Segments?.Select(seg => seg.Position);

			foreach (var point in points)
			{
				var p = Common.DeNormalizeCoordinates(point);
				dgvMy.Rows[p.Y].Cells[p.X].Value = Resources.ShipSegment;
			}
		}

		private void RenderRivalField()
		{
			IEnumerable<Point> points = null;
			if (_editableField.Enabled)
				points = _game.FieldGenerator.Ships
					.SelectMany(s => s.Segments)
					.Select(seg => seg.Position);
			else
				points = _game.Segments?.Select(seg => seg.Position);

			foreach (var point in points)
			{
				var p = Common.DeNormalizeCoordinates(point);
				dgvMy.Rows[p.Y].Cells[p.X].Value = Resources.ShipSegment;
			}
		}

		private void InitFields()
		{
			ClearField(dgvEnemy);
			ClearField(dgvMy);
		}

		private static void ClearField(DataGridView grid)
		{
			grid.Rows.Clear();
			for (int rowIndex = 1; rowIndex <= 10; rowIndex++)
			{
				var row = new DataGridViewRow() { Height = 24 };
				row.Cells.Add(new DataGridViewTextBoxCell() { Value = rowIndex, Style = grid.ColumnHeadersDefaultCellStyle });
				for (int colIndex = 1; colIndex <= 10; colIndex++)
					row.Cells.Add(new DataGridViewImageCell() { Value = Resources.EmptyCell });
				grid.Rows.Add(row);
			}
		}

		private void DgvMy_CellClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void BtnPCStart_Click(object sender, EventArgs e)
		{
			TryStartGameAsync();
		}

		private void TryStartGameAsync()
		{
			throw new NotImplementedException();
		}

		private void BtnRandomize_Click(object sender, EventArgs e)
		{
			_editableField.Disable();
			ClearField(dgvMy);
			_game.RandomizePlayerField();
			RenderMyField();
		}

		private void BtnSetManual_Click(object sender, EventArgs e)
		{
			ClearField(dgvMy);
			_game.FieldGenerator.ClearField();
			_editableField.BeginEdit(Game.AvailableShips);
		}

		private void DgvMy_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (!_editableField.Enabled)
				return;
			var p = Common.NormalizeCoordinates(e.ColumnIndex, e.RowIndex);
			_editableField.DrawFake(p.X, p.Y);
			RenderMyField();
		}

		private void DgvMy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			HandleMouseOnMyClick(e);
		}

		private void DgvEnemy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			HandleMouseOnEnemyClick(e);
		}

		private void HandleMouseOnMyClick(DataGridViewCellMouseEventArgs e)
		{
			if (!_editableField.Enabled) return;
			var p = Common.NormalizeCoordinates(e.ColumnIndex, e.RowIndex);
			if (e.Button == MouseButtons.Right)
			{
				_editableField.SwitchDirection();
				_editableField.DrawFake(p.X, p.Y);
			}
			if (e.Button == MouseButtons.Left)
			{
				var limit = Common.FieldSize - _editableField.CurrentShip;
				var x = !_editableField.IsVertical && p.X >= limit ? limit : p.X;
				var y = _editableField.IsVertical && p.Y >= limit ? limit : p.Y;
				if (_game.FieldGenerator.TryPutOnField(_editableField.CurrentShip, new Point(x, y), _editableField.IsVertical))
				{
					RenderMyField();
					if(!_editableField.MoveNext())
						tbMessages.AppendText("Setting up finished! You can start playing!\n");
				}
			}
		}

		private async void HandleMouseOnEnemyClick(DataGridViewCellMouseEventArgs e)
		{
			if (!_game.MyTurn || !_game.Ready()) return;

			var p = Common.NormalizeCoordinates(e.ColumnIndex, e.RowIndex);

			if (p.X < 0 || p.X > 9 || p.Y < 0 || p.Y > 9 || _game.IsUsed(p.X, p.Y))
				return;

			if (e.Button == MouseButtons.Left)
			{
				try
				{
					var shotResult = await _game.ShotAsync(p.X, p.Y);
					var targetCell = dgvEnemy.Rows[e.RowIndex].Cells[e.ColumnIndex];
					string msg = string.Empty;

					switch (shotResult.ResultType)
					{
						case ShotResultType.Missed:
							targetCell.Value = Resources.Missed;
							msg = "Sh@t! We missed! Waiting for enemy's shot...";
							break;
						case ShotResultType.Fired:
							targetCell.Value = Resources.Hit;
							msg = "Yes! We fired them!";
							break;
						case ShotResultType.Killed:
							targetCell.Value = Resources.Hit;
							msg = "Hooray! We sunk their ship!";
							if (!shotResult.StillAlive)
							{
								msg += "\nWe won! It's the end. You are the best of the best! :)";
								DisposeGame();
							}
							break;
						default:
							throw new ApplicationException("Unknown result type");
					}
					tbMessages.AppendText(msg + "\n");
					return;
				}
				catch
				{
					// ignored
				}
				DisposeGame();
				RenderMyField();
				tbMessages.AppendText("Error occured. Session closed.\n");				
			}
		}

		private async void BtnHostGame_Click(object sender, EventArgs e)
		{
			await InitNetworkGame(true);
		}

		private async void BtnJoinGame_Click(object sender, EventArgs e)
		{
			await InitNetworkGame(false);
		}

		private async Task InitNetworkGame(bool isHost)
		{
			ClearField(dgvEnemy);
			ClearField(dgvMy);
			RenderMyField();
			if (_game.FieldGenerator.HasValidSet())
			{
				btnHostGame.Enabled = false;
				btnJoinGame.Enabled = false;
				tbAddress.Enabled = false;
				tbPort.Enabled = false;
				tbMessages.AppendText("Connecting...\n");
				_game.InitializeNetworkGame();
				var ip = tbAddress.Text;
				int.TryParse(tbPort.Text, out int port);
				var success = await _game.StartNetworkGameAsync(ip, port, isHost);
				if (success)
				{
					tbMessages.AppendText("Connected\n");
					RenderRivalField();
				}
				else
				{
					btnHostGame.Enabled = true;
					btnJoinGame.Enabled = true;
					tbAddress.Enabled = true;
					tbPort.Enabled = true;
					tbMessages.AppendText("Error while connecting. Check connection!");
				}
			}
			else
			{
				tbMessages.AppendText("Please, set up your field\n");
			}
		}

		private void DisposeGame()
		{
			btnHostGame.Enabled = true;
			btnJoinGame.Enabled = true;
			tbAddress.Enabled = true;
			tbPort.Enabled = true;
			_game.Dispose();
		}
	}
}
