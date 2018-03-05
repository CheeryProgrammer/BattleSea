using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameLogic.Player
{
	class HostPlayer : IPlayer
	{
		private Socket _client;
		public bool Ready => true;

		public IReadOnlyCollection<Ship> Ships => throw new NotImplementedException();

		public HostPlayer(int fieldSize)
		{

		}

		public async Task<bool> Initialize(List<Ship> ships = null)
		{
			return await CreateConnectionAsync();
		}

		private Task<bool> CreateConnectionAsync()
		{
			var connectionTask = Task.Run(() =>
			{
				var dns = Dns.GetHostEntry("localhost");
				var localEndpoint = new IPEndPoint(dns.AddressList[1], 2604);
				var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Bind(localEndpoint);
				socket.Listen(2);
				_client = socket.Accept();
				return true;
			});

			connectionTask.ContinueWith(t =>
			{
				ListenMessages();	
			}, TaskContinuationOptions.OnlyOnRanToCompletion);
			return connectionTask;
		}

		private void ListenMessages()
		{
			while (true)
			{
				while (_client.Available <= 0)
					Thread.Sleep(10);

				string msg = string.Empty;
				while (_client.Available > 0)
				{
					var buffer = new byte[256];
					var receivedCount = _client.Receive(buffer, buffer.Length, SocketFlags.None);
					msg += Encoding.ASCII.GetString(buffer, 0, receivedCount);
				}

				var sendData = Encoding.ASCII.GetBytes("Got you pidarrr!");
				_client.Send(sendData, sendData.Length, SocketFlags.None);
				Console.WriteLine(msg);
			}
		}
	}
}
