using Network;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	class NetworkPlayer : IRival
	{
		public bool Ready => true;
		private ISocket _server;
		private string _lastMessage;
		private AutoResetEvent _responseWaiter = new AutoResetEvent(false);

		public event EventHandler<ShotEvent> OnShot;

		public Task<bool> Initialize(string ip, int port, bool isHost)
		{
			return Task.Run(()=>
			{
				try
				{
					_server = isHost
						? (ISocket)new SocketServer(ip, port)
						: new SocketClient(ip, port);
					_server.OnMessageReceived += OnMessageReceived;
					return _server.InitializeSocket().Result;
				}
				catch
				{
					// ignored
				}
				return false;
			});
		}

		private void OnMessageReceived(object sender, string e)
		{
			_lastMessage = e;
			_responseWaiter.Set();
			if(!RaiseEventIfShot(_lastMessage))
				_responseWaiter.Set();
		}

		private bool RaiseEventIfShot(string message)
		{
			int x, y;
			if (TryParseShot(message, out x, out y))
			{
				OnShot?.Invoke(this, new ShotEvent(x, y));
				return true;
			}
			return false;
		}

		private bool TryParseShot(string message, out int x, out int y)
		{
			x = -1;
			y = -1;
			var tokens = message.Split('_');
			if (!tokens[0].Equals("shot"))
				return false;

			return int.TryParse(tokens[1], out x) && int.TryParse(tokens[2], out y);
		}

		public Task<ShotResult> Shot(int x, int y)
		{
			return Task.Run(() =>
			{
				var response = _server.Request($"shot_{x}_{y}");
				return ParseResponse(response);
			});
		}

		private ShotResult ParseResponse(string message)
		{
			ShotResultType resultType;
			switch (message)
			{
				case "fired":
					resultType = ShotResultType.Fired;
					break;
				case "killed":
					resultType = ShotResultType.Killed;
					break;
				case "missed":
					resultType = ShotResultType.Missed;
					break;
				default:
					throw new ApplicationException("Unknown shot response");
			}

			return new ShotResult(0, 0, resultType, true);
		}

		public void ReturnMissed()
		{
			_server.Send("missed");
		}

		public void ReturnFired()
		{
			_server.Send("fired");
		}

		public void ReturnKilled()
		{
			_server.Send("killed");
		}
	}
}
