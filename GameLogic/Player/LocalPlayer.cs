using GameLogic.Player;
using System;
using System.Collections.Generic;
using System.Linq;
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
		
		public bool TryShot(int x, int y)
		{
			var p = new Point(x, y);
			return _ships.Any(s=>s.AcceptShot(p));
		}
	}
}