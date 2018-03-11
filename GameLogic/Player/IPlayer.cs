using System;
using System.Collections.Generic;

namespace GameLogic.Player
{
	public interface IPlayer: IDisposable
	{
		bool Ready { get; }
		IReadOnlyCollection<Ship> Ships { get; }
		bool Initialize(string ip = null, int port = 0);
		ShotResult Shot(int x, int y);
	}
}
