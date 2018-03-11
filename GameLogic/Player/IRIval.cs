using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	public interface IRival
	{
		bool Ready { get; }
		event EventHandler<ShotEvent> OnShot;
		Task<bool> TryShot(int x, int y);
		IReadOnlyCollection<Point> Missed { get; }
		IReadOnlyCollection<Point> Fired { get; }
		Task<bool> Initialize(string ip, int port, bool isHost);
		void ReturnMissed();
		void ReturnFired();
	}

	public class ShotEvent
	{
		public int X { get; }
		public int Y { get; }

		public ShotEvent(int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	public class ShotResultEvent : ShotEvent
	{
		public bool Result { get; }
		public ShotResultEvent(int x, int y, bool result):base(x, y)
		{
			Result = result;
		}
	}
}
