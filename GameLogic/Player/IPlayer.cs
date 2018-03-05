using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	public interface IPlayer
	{
		bool Ready { get; }
		IReadOnlyCollection<Ship> Ships { get; }
		Task<bool> Initialize(List<Ship> ships = null);
	}
}
