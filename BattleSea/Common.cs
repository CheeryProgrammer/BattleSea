using GameLogic;

namespace BattleSea
{
	public static class Common
	{
		public static Point NormalizeCoordinates(int x, int y)
		{
			return new Point(x - 1, y);
		}

		public static Point DeNormalizeCoordinates(Point norm)
		{
			return new Point(norm.X + 1, norm.Y);
		}

		public static Point DeNormalizeCoordinates(int x, int y)
		{
			return new Point(x + 1, y);
		}

		public const int FieldSize = 10;
	}
}
