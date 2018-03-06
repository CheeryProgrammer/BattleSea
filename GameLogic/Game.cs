﻿using GameLogic.Player;
using GameLogic.ShipStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLogic
{
	public class Game
	{
		public FieldSetGenerator FieldGenerator { get; private set; }
		private IPlayer _player;
		private IPlayer _rival;

		public static readonly int[] AvailableShips = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

		public IReadOnlyCollection<Segment> Segments { get => Player.Ships.SelectMany(s => s.Segments).ToList(); }

		public IPlayer Player
		{
			get { return _player; }
		}

		public Game(int fieldSize)
		{
			FieldGenerator = new FieldSetGenerator(AvailableShips, fieldSize);
			_player = new ClientPlayer(FieldGenerator.GenerateField());
			_rival = new HostPlayer(FieldGenerator.GenerateField());
		}

		public async Task<bool> StartGameAsync()
		{
			return _rival.Initialize("127.0.0.1", 2604)
				&& _player.Initialize("127.0.0.1", 2604);
		}

		public void OnMyFieldClick(int x, int y)
		{
			Player.TryShot(x, y);
		}

		public void RandomizePlayerField()
		{
			var ships = FieldGenerator.GenerateField();
			_player = new LocalPlayer(ships);
		}

		public bool ReadyToPlay()
		{
			return Player.Ready && _rival.Ready;
		}

		public void PrepareLocalPlayer()
		{
			Player.Initialize();
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
