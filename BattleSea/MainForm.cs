using BattleSea.Properties;
using GameLogic;
using System;
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
			_game = new Game();
			_editableField = new EditableField(dgvMy);
		}

		private void RenderMyField()
		{
			if(_game.Segments != null)
				foreach (var point in _game.Segments)
					dgvMy.Rows[point.Y].Cells[point.X + 1].Value = Resources.Irina;
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

		private void dgvMy_CellClick(object sender, DataGridViewCellEventArgs e)
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

		private void btnRandomize_Click(object sender, EventArgs e)
		{
			ClearField(dgvMy);
			_game.RandomizePlayerField();
			RenderMyField();
		}

		private void btnSetManual_Click(object sender, EventArgs e)
		{
			ClearField(dgvMy);
			_editableField.BeginEdit(Game.AvailableShips);
		}

		private void dgvMy_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			tbMessages.AppendText($"X: {e.ColumnIndex}, Y: {e.RowIndex}\n");
			_editableField.DrawFake(e.ColumnIndex, e.RowIndex);
			RenderMyField();
		}

		private void dgvMy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				_editableField.SwitchDirection();
				_editableField.DrawFake(e.ColumnIndex, e.RowIndex);
			}
			if (e.Button == MouseButtons.Left)
			{
				if (_game.Player.TryPutOnField(_editableField.CurrentShip, new Point(e.ColumnIndex, e.RowIndex),
					_editableField.IsVertical))
					;
			}
		}
	}
}
