using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	public interface IPlayer
	{
		bool Ready { get; }
		IReadOnlyCollection<Ship> Ships { get; }
		bool Initialize(string ip = null, int port = 0);
		bool TryShot(int x, int y);
	}
}
