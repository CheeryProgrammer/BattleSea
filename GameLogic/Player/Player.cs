﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
	public class Player
	{
		private readonly int _fieldSize;
		private int[] _availableShips;
		private List<Ship> _ships;
		public IReadOnlyCollection<Point> Segments
		{
			get { return _ships?.SelectMany(ship => ship.Points()).ToList(); }
		}


		public Player(int fieldSize)
		{
			_fieldSize = fieldSize;
			_availableShips = Game.AvailableShips;
			_ships = new List<Ship>(_availableShips.Length);
		}

		public void GenerateField()
		{
			_ships = new List<Ship>(_availableShips.Length);
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

				} while (!success);
			}
		}

		public bool TryPutOnField(int ship, Point point, bool isVertical)
		{
			if (!IsValidInitialPoint(point, ship, isVertical))
				return false;

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

			var points = new List<Point>();
			for (int j = 0; j < ship; j++)
			{
				points.Add(point);
				point = isVertical
					? new Point(point.X, point.Y + 1)
					: new Point(point.X + 1, point.Y);
			}
			_ships.Add(new Ship(points, isVertical));

			return true;
		}

		private bool IsValidInitialPoint(Point point, int segmentsCount, bool isVertical)
		{
			var endX = point.X;
			var endY = point.Y;
			if (isVertical)
				endY += segmentsCount - 1;
			else
				endX += segmentsCount - 1;
			return point.X >= 0 && point.Y >= 0 && endX < _fieldSize && endY < _fieldSize;
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

		public void ClearField()
		{
			_ships = new List<Ship>();
		}
	}
}