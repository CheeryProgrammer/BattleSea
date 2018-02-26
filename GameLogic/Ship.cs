using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
	internal class Ship
	{
		private Dictionary<Point, CellState> _pointToState;

		public Ship(IReadOnlyCollection<Point> points, bool isVertical)
		{
			_pointToState = new Dictionary<Point, CellState>();
			foreach (var p in points)
				_pointToState[p] = CellState.ShipSegment;
		}

		public IEnumerable<Point> Points()
		{
			return _pointToState.Keys;
		}

		internal bool HasPoint(int x, int y)
		{
			return _pointToState.Keys.Any(point => point.X == x && point.Y == y);
		}
	}
}