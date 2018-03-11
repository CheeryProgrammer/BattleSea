using System;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	public interface IRival: IDisposable
	{
		bool Ready { get; }
		event EventHandler<ShotEvent> OnShot;
		Task<ShotResult> Shot(int x, int y);
		Task<bool> Initialize(string ip, int port, bool isHost);
		void ReturnResult(ShotResult result);
	}
}
