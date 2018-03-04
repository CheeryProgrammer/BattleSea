using GameLogic.Player;
using System;
using System.Collections.Generic;

namespace GameLogic
{
	public class LocalPlayer : IPlayer
	{
		private readonly int _fieldSize;
		private int[] _availableShips;
		private List<Ship> _ships;
		private bool _isReady;

		public bool Ready { get => _isReady; }

		public IReadOnlyCollection<Ship> Ships => _ships;

		public LocalPlayer(int fieldSize)
		{
			_fieldSize = fieldSize;
			_availableShips = Game.AvailableShips;
			_ships = new List<Ship>(_availableShips.Length);
		}

		internal void SetReady()
		{
			_isReady = true;
		}

		public bool Initialize(List<Ship> ships = null)
		{
			_ships = ships;
			return true;
		}
	}
}