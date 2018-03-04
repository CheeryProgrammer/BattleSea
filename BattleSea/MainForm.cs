using BattleSea.Properties;
using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
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
			_game = new Game(Common.FieldSize);
			_editableField = new EditableField(dgvMy);
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
			OnMyFieldClick(e.ColumnIndex, e.RowIndex);
		}

		private void OnMyFieldClick(int columnIndex, int rowIndex)
		{
			_game.OnMyFieldClick(columnIndex, rowIndex);
		}

		private void btnPCStart_Click(object sender, EventArgs e)
		{
			TryStartGame();
		}

		private void TryStartGame()
		{
			if(_game.ReadyToPlay())
				_game.StartGame();
		}

		private void BtnRandomize_Click(object sender, EventArgs e)
		{
			ClearField(dgvMy);
			_game.RandomizePlayerField();
			RenderMyField();
		}

		private void BtnSetManual_Click(object sender, EventArgs e)
		{
			ClearField(dgvMy);
			_game.FieldGenerator.ClearField();
			_game.Player.Initialize();
			_editableField.BeginEdit(Game.AvailableShips);
		}

		private void DgvMy_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			var p = Common.NormalizeCoordinates(e.ColumnIndex, e.RowIndex);
			tbMessages.AppendText($"X: {e.ColumnIndex}, Y: {e.RowIndex} => Xn: {p.X}, Yn: {p.Y}\n");
			_editableField.DrawFake(p.X, p.Y);
				RenderMyField();
		}

		private void DgvMy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
				if (_game.FieldGenerator.TryPutOnField(_editableField.CurrentShip, new Point(x,y), _editableField.IsVertical))
				{
					RenderMyField();
					if (!_editableField.MoveNext())
						_game.PrepareLocalPlayer();
				}
			}
		}
	}
}
