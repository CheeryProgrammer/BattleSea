namespace GameLogic.ShipStuff
{
	public class Segment
	{
		public SegmentState State { get; set; }
		public Point Position { get; }

		public Segment(Point point)
		{
			Position = point;
		}

		public bool TryAcceptShot(Point p)
		{
			if (Position.X == p.X && Position.Y == p.Y)
			{
				State = SegmentState.Fired;
				return true;
			}
			return false;
		}
	}

	public enum SegmentState
	{
		Alive,
		Fired
	}
}
