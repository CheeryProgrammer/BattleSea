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

		public ShotResult Shot(int x, int y)
		{
			var p = new Point(x, y);
			var resultType = ShotResultType.Missed;
			var ship = _ships.FirstOrDefault(s => s.TryAcceptShot(p));
			if (ship != null)
			{
				resultType = ship.IsAlive
					? ShotResultType.Fired
					: ShotResultType.Killed;
			}

			var result = new ShotResult(x, y, resultType, _ships.Any(s => s.IsAlive));
			if (ship != null && !ship.IsAlive)
			{
				result.SetKilledSegments(ship.Segments);
			}
			return result;
		}
	}
}