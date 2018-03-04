using BattleSea.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace BattleSea
{
	class EditableField
	{
		private Dictionary<DataGridViewCell, object> _cellToValue = new Dictionary<DataGridViewCell, object>();
		private DataGridView _grid;
		private bool _isManualMode;
		private bool _isVertical = false;
		private int[] _ships;
		public int CurrentShip => _ships[_shipIndex];

		public bool IsVertical
		{
			get { return _isVertical; }
		}

		public bool Enabled {
			get { return _isManualMode; }
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
			_shipIndex = 0;
		}

		internal void DrawFake(int col, int row)
		{
			if (!_isManualMode) return;
			RestoreCells();
			if (PossibleToPlace(col, row))
			{
				if (IsVertical)
				{
					if (row >= 10 - CurrentShip)
						row = 10 - CurrentShip;
				}
				else
				{
					if (col > 10 - CurrentShip)
						col = 10 - CurrentShip;
				}
				DrawFakeShip(col, row);
			}
		}

		private bool PossibleToPlace(int columnIndex, int rowIndex)
		{
			if (rowIndex < 0 || columnIndex < 0)
				return false;
			if (IsVertical)
				return rowIndex < 10;
			return columnIndex < 10;
		}

		private void DrawFakeShip(int columnIndex, int rowIndex)
		{
			var p = Common.DeNormalizeCoordinates(columnIndex, rowIndex);
			columnIndex = p.X;
			rowIndex = p.Y;
			for (int i = 0; i < CurrentShip; i++)
			{
				var cell = _grid.Rows[rowIndex].Cells[columnIndex];
				_cellToValue.Add(cell, cell.Value);
				cell.Value = Resources.FantomSegment;
				if (IsVertical) rowIndex++;
				else columnIndex++;
			}
		}

		private void RestoreCells()
		{
			var keys = _cellToValue.Keys.ToList();
			foreach (var cell in keys)
			{
				object value;
				if (_cellToValue.TryGetValue(cell, out value))
				{
					cell.Value = value;
					_cellToValue.Remove(cell);
				}
			}
		}

		internal void SwitchDirection()
		{
			if (!_isManualMode) return;
			_isVertical = !IsVertical;
		}

		public bool MoveNext()
		{
			_shipIndex++;
			if (!(_shipIndex < _ships.Length))
			{
				_isManualMode = false;
				return false;
			}
			return true;
		}
	}
}
