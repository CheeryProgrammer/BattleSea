using GameLogic.ShipStuff;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
	public class Ship
	{
		private List<Segment> _segments;
		public bool IsAlive
		{
			get
			{
				return _segments.Any(seg => seg.State == SegmentState.Alive);
			}
		}

		public Ship(IReadOnlyCollection<Point> points)
		{
			_segments = new List<Segment>();
			foreach (var p in points)
				_segments.Add(new Segment(p));
		}

		public IReadOnlyCollection<Segment> Segments
		{
			get { return _segments; }
		}

		public bool TryAcceptShot(Point p)
		{
			return _segments.Any(seg => seg.TryAcceptShot(p));
		}

		internal bool TryFire(int x, int y)
		{
			var seg = _segments.FirstOrDefault(s=>s.Position.X == x && s.Position.Y == y);
			if (seg == null)
				return false;

			seg.State = SegmentState.Fired;
			return true;
		}
	}
}