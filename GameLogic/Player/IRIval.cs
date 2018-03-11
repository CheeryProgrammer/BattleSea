using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	public interface IRival
	{
		bool Ready { get; }
		event EventHandler<ShotEvent> OnShot;
		Task<ShotResult> Shot(int x, int y);
		Task<bool> Initialize(string ip, int port, bool isHost);
		void ReturnMissed();
		void ReturnFired();
		void ReturnKilled();
	}
}
