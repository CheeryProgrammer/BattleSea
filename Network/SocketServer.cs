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
	public class SocketServer: ISocket
	{
		private static readonly object _locker = new object();

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

		private void InitializeSocket(string ip, int port)
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
			listeningTask.Wait();
		}

		private void ListenMessages()
		{
			while (!_cancellationTokenSource.Token.IsCancellationRequested)
			{
				WaitForInputData();
				lock (_locker)
				{
					string msg = ReadMessage();
					OnMessageReceived?.Invoke(this, msg);
				}
			}
		}

		private string ReadMessage()
		{
			string msg = string.Empty;
			while (_client.Available > 0)
			{
				var buffer = new byte[256];
				var receivedCount = _client.Receive(buffer, buffer.Length, SocketFlags.None);
				msg += Encoding.ASCII.GetString(buffer, 0, receivedCount);
			}
			return msg;
		}

		public void Send(string message)
		{
			var sendData = Encoding.ASCII.GetBytes(message);
			_client.Send(sendData, sendData.Length, SocketFlags.None);
		}

		private void WaitForInputData()
		{
			while (_client.Available <= 0)
				Thread.Sleep(10);
		}

		public string Request(string message)
		{
			lock (_locker)
			{
				Send(message);
				WaitForInputData();
				return ReadMessage();
			}
		}
	}
}
