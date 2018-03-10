using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
	public class SocketClient: ISocket
	{
		private static readonly object _locker = new object();

		private Socket _socket;
		private CancellationTokenSource _cancellationTokenSource;

		public event EventHandler<string> OnMessageReceived;

		public SocketClient(string ip, int port)
		{
			if (string.IsNullOrWhiteSpace(ip))
				throw new ArgumentException();
			_cancellationTokenSource = new CancellationTokenSource();
			InitializeSocket(ip, port);
		}

		private void InitializeSocket(string ip, int port)
		{
			_cancellationTokenSource.Cancel();
			_cancellationTokenSource = new CancellationTokenSource();
			var connectingTask = Task.Run(() =>
			{
				var hostEntry = Dns.GetHostEntry(ip);
				var address = hostEntry.AddressList[0];
				_socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				_socket.Connect(new IPEndPoint(address, port));
			});
			connectingTask.ContinueWith(t=>
			{
				ListenMessages();
			}, _cancellationTokenSource.Token);
			connectingTask.Wait();
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

		private void WaitForInputData()
		{
			while (_socket.Available <= 0)
				Thread.Sleep(10);
		}

		private string ReadMessage()
		{
			string msg = string.Empty;
			while (_socket.Available > 0)
			{
				var buffer = new byte[256];
				var receivedCount = _socket.Receive(buffer, buffer.Length, SocketFlags.None);
				msg += Encoding.ASCII.GetString(buffer, 0, receivedCount);
			}
			return msg;
		}

		public void Send(string message)
		{
			var sendData = Encoding.ASCII.GetBytes(message);
			_socket.Send(sendData, sendData.Length, SocketFlags.None);
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
