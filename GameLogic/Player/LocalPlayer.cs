using GameLogic.Player;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLogic
{
	public class LocalPlayer : IPlayer
	{
		private List<Ship> _ships;
		private bool _isReady;

		public bool Ready { get => _isReady; }

		public IReadOnlyCollection<Ship> Ships => _ships;

		public LocalPlayer(List<Ship> ships)
		{
			_ships = ships;
		}

		internal void SetReady()
		{
			_isReady = true;
		}

		public bool Initialize(string ip = null, int port = 0)
		{
			SetReady();
			return true;
		}
		
		public Task<bool> TryShot(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}