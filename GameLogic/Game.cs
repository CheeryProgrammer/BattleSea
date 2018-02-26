using System;
using System.Collections.Generic;

namespace GameLogic
{
	public class Game
	{
		private Player _player;
		private Player _rival;

		public static readonly int[] AvailableShips = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

		public IReadOnlyCollection<Point> Segments { get => Player.Segments; }

		public Player Player
		{
			get { return _player; }
		}

		public Game()
		{
			_player = new Player();
			_rival = new Player();
		}

		public void StartGame()
		{
			throw new NotImplementedException();
		}

		public void OnMyFieldClick(int columnIndex, int rowIndex)
		{
		}

		public void RandomizePlayerField()
		{
			Player.GenerateField();
		}

		public bool ReadyToPlay()
		{
			return Player.IsReady() && _rival.IsReady();
		}
	}

	public static class Randomizer
	{
		private static Random _rnd = new Random();

		public static bool ThrowCoin()
		{
			return _rnd.Next(0, 2) == 1;
		}

		public static int FromInterval(int min, int max)
		{
			return _rnd.Next(min, max + 1);
		}
	}

	public struct Point
	{
		public int X;
		public int Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	public enum CellState
	{
		Empty,
		ShipSegment,
		Missed,
		Fired,
		Destroyed,
	}
}
