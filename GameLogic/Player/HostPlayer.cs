﻿using Network;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	class HostPlayer : IPlayer
	{
		private SocketServer _server;
		private List<Ship> _ships;
		private string _lastMessage;
		private AutoResetEvent _responseWaiter = new AutoResetEvent(false);

		public bool Ready => true;

		public IReadOnlyCollection<Ship> Ships => _ships;

		public HostPlayer(List<Ship> ships)
		{
			_ships = ships;
		}

		public bool Initialize(string ip = null, int port = -1)
		{
			try
			{
				_server = new SocketServer(ip, port);
				_server.OnMessageReceived += OnMessageReceived;
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
			_responseWaiter.Set();
		}

		public async Task<bool> TryShot(int x, int y)
		{
			var task = Task.Run<bool>(() =>
			{
				_server.Send($"shot_{x}_{y}");
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
