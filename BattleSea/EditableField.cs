using BattleSea.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleSea
{
	class EditableField
	{
		private DataGridView _grid;
		private bool _isManualMode;
		private bool _isVertical = false;
		private int[] _ships;
		public int CurrentShip => _ships[_shipIndex];

		public bool IsVertical
		{
			get { return _isVertical; }
		}

		private int _shipIndex;
		private Queue<DataGridViewCell> _fakeCells = new Queue<DataGridViewCell>();

		public EditableField(DataGridView grid)
		{
			_grid = grid;
		}

		internal void BeginEdit(int[] ships)
		{
			_isManualMode = true;
			_ships = ships;
		}

		internal void DrawFake(int col, int row)
		{
			if (!_isManualMode) return;
			ClearFake();
			if (PossibleToPlace(col, row))
			{
				if (IsVertical)
				{
					if (row >= 10 - CurrentShip)
						row = 10 - CurrentShip;
				}
				else
				{
					if (col > 11 - CurrentShip)
						col = 11 - CurrentShip;
				}
				DrawFakeShip(col, row);
			}
		}

		private bool PossibleToPlace(int columnIndex, int rowIndex)
		{
			if (rowIndex < 0 || columnIndex <= 0)
				return false;
			if (IsVertical)
				return rowIndex < 11;
			return columnIndex <= 11;
		}

		private void DrawFakeShip(int columnIndex, int rowIndex)
		{
			for (int i = 0; i < CurrentShip; i++)
			{
				var cell = _grid.Rows[rowIndex].Cells[columnIndex];
				_fakeCells.Enqueue(cell);
				cell.Value = Resources.ShipSegment;
				if (IsVertical) rowIndex++;
				else columnIndex++;
			}
		}

		private void ClearFake()
		{
			while (_fakeCells.Count > 0)
				_fakeCells.Dequeue().Value = Resources.EmptyCell;
		}

		internal void SwitchDirection()
		{
			if (!_isManualMode) return;
			_isVertical = !IsVertical;
		}
	}
}
