using GameLogic.ShipStuff;
using System.Collections.Generic;

namespace GameLogic
{
	public class ShotResult
	{
		public int X { get; }
		public int Y { get; }
		public ShotResultType ResultType { get; }
		public bool StillAlive { get; }
		public IReadOnlyCollection<Segment> KilledSegments { get; private set; }

		public ShotResult(int x, int y, ShotResultType resultType, bool stillAlive)
		{
			X = x;
			Y = y;
			ResultType = resultType;
			StillAlive = stillAlive;
		}

		public void SetKilledSegments(IReadOnlyCollection<Segment> segments)
		{
			KilledSegments = segments;
		}
	}

	public enum ShotResultType
	{
		Missed,
		Fired,
		Killed
	}
}
