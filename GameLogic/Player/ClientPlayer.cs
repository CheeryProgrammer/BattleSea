using Network;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	class ClientPlayer : IPlayer
	{
		public bool Ready => true;
		private List<Ship> _ships;
		private SocketClient _socketClient;
		private string _lastMessage;
		private AutoResetEvent _responseWaiter = new AutoResetEvent(false);

		public IReadOnlyCollection<Ship> Ships => _ships;

		public ClientPlayer(List<Ship> ships)
		{
			_ships = ships;
		}

		public bool Initialize(string ip = null, int port = -1)
		{
			try
			{
				_socketClient = new SocketClient(ip, port);
				_socketClient.OnMessageReceived += OnMessageReceived;
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void OnMessageReceived(object sender, string e)
		{
			_lastMessage = e;
		}

		public async Task<bool> TryShot(int x, int y)
		{
			var task = Task.Run<bool> (() =>
			{
				_socketClient.Send($"shot_{x}_{y}");
				_responseWaiter.WaitOne();
				return ParseResponse(_lastMessage);
			});
			return await task;
		}

		private bool ParseResponse(string lastMessage)
		{
			return bool.TryParse(lastMessage, out bool response) && response;
		}
	}
}
