using GameLogic.Player;
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
		private IRival _rival;
		public bool MyTurn { get; private set; }
		public static readonly int[] AvailableShips = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

		public event EventHandler<ShotResultEvent> OnShot;

		public IReadOnlyCollection<Segment> Segments { get => FieldGenerator.Ships.SelectMany(s => s.Segments).ToList(); }

		public IPlayer Player
		{
			get { return _player; }
		}

		public Game(int fieldSize)
		{
			FieldGenerator = new FieldSetGenerator(AvailableShips, fieldSize);			
		}

		public async Task<bool> StartNetworkGameAsync(string ip, int port, bool isHost = true)
		{
			MyTurn = isHost;
			return await _rival.Initialize(ip, port, isHost)
				&& _player.Initialize();
		}

		public Task<bool> ShotAsync(int x, int y)
		{
			return _rival.TryShot(x, y).ContinueWith( t =>
			{
				MyTurn = t.Result;
				return MyTurn;
			});
		}

		public void RandomizePlayerField()
		{
			var ships = FieldGenerator.GenerateField();
			_player = new LocalPlayer(ships);
		}

		public bool Ready()
		{
			return _player != null
				&& _player.Ready
				&& _rival != null
				&& _rival.Ready;
		}

		public void InitializeNetworkGame()
		{
			_player = new LocalPlayer(FieldGenerator.Ships.ToList());
			_rival = new NetworkPlayer();
			_rival.OnShot += Rival_OnShot;
		}

		private void Rival_OnShot(object sender, ShotEvent e)
		{
			var rival = sender as IRival;
			bool result = _player.TryShot(e.X, e.Y);
			if (result)
			{
				rival.ReturnFired();
			}
			else
			{
				rival.ReturnMissed();
				MyTurn = true;
			}
			OnShot?.Invoke(this, new ShotResultEvent(e.X, e.Y, result));
		}

		public void InitializeJoinGame()
		{
			_player = new LocalPlayer(FieldGenerator.Ships.ToList());
			_rival = new NetworkPlayer();
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
