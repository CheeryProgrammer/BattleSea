using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
	public class SocketServer
	{
		private Socket _socket;
		private CancellationTokenSource _cancellationTokenSource;
		private Socket _client;

		public event EventHandler<string> OnMessageReceived;

		public SocketServer(string ip, int port)
		{
			_cancellationTokenSource = new CancellationTokenSource();
			if (string.IsNullOrWhiteSpace(ip))
				throw new ArgumentException();
			InitializeSocket(ip, port);
		}

		private async void InitializeSocket(string ip, int port)
		{
			_cancellationTokenSource.Cancel();
			_cancellationTokenSource = new CancellationTokenSource();
			var listeningTask = Task.Run(() =>
			{
				var hostEntry = Dns.GetHostEntry(ip);
				var address = hostEntry.AddressList[0];
				_socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				_socket.Bind(new IPEndPoint(address, port));
				_socket.Listen(2);
				_client = _socket.Accept();
			});
			listeningTask.ContinueWith(t =>
			{
				ListenMessages();
			}, _cancellationTokenSource.Token);
			await listeningTask;
		}

		private void ListenMessages()
		{
			while (!_cancellationTokenSource.Token.IsCancellationRequested)
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
				OnMessageReceived?.Invoke(this, msg);
			}
		}

		public void Send(string message)
		{
			var sendData = Encoding.ASCII.GetBytes(message);
			_socket.Send(sendData, sendData.Length, SocketFlags.None);
		}
	}
}
