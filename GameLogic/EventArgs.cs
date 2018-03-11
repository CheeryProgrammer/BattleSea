namespace GameLogic
{
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
		public ShotResult Result { get; }
		public ShotResultEvent(int x, int y, ShotResult result):base(x, y)
		{
			Result = result;
		}
	}
}
