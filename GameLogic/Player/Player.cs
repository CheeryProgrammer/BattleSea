using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
	public class Player
	{
		//private CellState[,] _field;
		private int[] _availableShips;
		private Ship[] _ships;
		public IReadOnlyCollection<Point> Segments
		{
			get { return _ships?.SelectMany(ship => ship.Points()).ToList(); }
		}

		//public CellState[,] Field { get => _field; }

		public Player()
		{
			_availableShips = Game.AvailableShips;
			//_field = new CellState[10, 10];
		}

		public void GenerateField()
		{
			_ships = new Ship[_availableShips.Length];
			for (int i = 0; i < _availableShips.Length; i++)
			{
				var ship = _availableShips[i];
				var isVertical = Randomizer.ThrowCoin();
				Point point;
				bool success;
				do
				{
					point = GenerateInitialPosition(ship, isVertical);
					success = TryPutOnField(ship, point, isVertical);
					if (success)
					{
						var points = new List<Point>();
						for (int j = 0; j < ship; j++)
						{
							points.Add(point);
							point = isVertical
								? new Point(point.X, point.Y + 1)
								: new Point(point.X + 1, point.Y);
						}
						_ships[i] = new Ship(points, isVertical);
					}

				} while (!success);
			}
		}

		public bool TryPutOnField(int ship, Point point, bool isVertical)
		{
			var currentPoint = isVertical ? new Point(point.X, point.Y) : new Point(point.Y, point.X);
			int b = currentPoint.X;
			int a = currentPoint.Y;
			var success = true;

			for (int i = a - 1; i <= a + ship; i++)
			{
				for (int j = b - 1; j <= b + 1; j++)
				{
					success &= (isVertical ? IsAllowedNeighborgood(j, i) : IsAllowedNeighborgood(i, j));
					if (!success)
						return false;
				}
			}

			return true;
		}

		internal bool IsReady()
		{
			throw new NotImplementedException();
		}

		private bool IsAllowedNeighborgood(int x, int y)
		{
			return x < 0 || x > 9 || y < 0 || y > 9 || IsCellEmpty(x, y);
		}

		private Point GenerateInitialPosition(int segmentCount, bool isVertical)
		{
			var coord1 = Randomizer.FromInterval(0, 9);
			var coord2 = Randomizer.FromInterval(0, 10 - segmentCount);
			return isVertical ? new Point(coord1, coord2) : new Point(coord2, coord1);
		}

		private bool IsCellEmpty(int x, int y)
		{
			return _ships != null
				&& !_ships.Any(ship => ship != null && ship.HasPoint(x, y));
		}
	}
}