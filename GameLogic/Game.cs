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
		private bool[,] _used;
		public bool MyTurn { get; private set; }
		public static readonly int[] AvailableShips = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
		private readonly int _fieldSize;

		public event EventHandler<ShotResultEvent> OnEnemyShot;

		public IReadOnlyCollection<Segment> Segments { get => FieldGenerator.Ships.SelectMany(s => s.Segments).ToList(); }

		public IPlayer Player
		{
			get { return _player; }
		}

		public Game(int fieldSize)
		{
			_fieldSize = fieldSize;
			FieldGenerator = new FieldSetGenerator(AvailableShips, fieldSize);
		}

		public async Task<bool> StartNetworkGameAsync(string ip, int port, bool isHost = true)
		{
			MyTurn = isHost;
			return await _rival.Initialize(ip, port, isHost)
				&& _player.Initialize();
		}

		public Task<ShotResult> ShotAsync(int x, int y)
		{
			_used[x, y] = true;
			return _rival.Shot(x, y).ContinueWith( t =>
			{
				MyTurn = t.Result.ResultType != ShotResultType.Missed;
				return t.Result;
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
			_used = new bool[_fieldSize, _fieldSize];
			_player = new LocalPlayer(FieldGenerator.Ships.ToList());
			_rival = new NetworkPlayer();
			_rival.OnShot += Rival_OnShot;
		}

		private void Rival_OnShot(object sender, ShotEvent e)
		{
			var rival = sender as IRival;
			ShotResult result = _player.Shot(e.X, e.Y);
			rival.ReturnResult(result);
			MyTurn = result.ResultType == ShotResultType.Missed;
			OnEnemyShot?.Invoke(this, new ShotResultEvent(e.X, e.Y, result));
		}

		public void InitializeJoinGame()
		{
			_player = new LocalPlayer(FieldGenerator.Ships.ToList());
			_rival = new NetworkPlayer();
		}

		public bool IsUsed(int x, int y)
		{
			return _used != null && _used[x, y];
		}

		public void Dispose()
		{
			_player?.Dispose();
			_rival?.Dispose();
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
