using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Network
{
	public abstract class SocketBase
	{
		private static readonly object _locker = new object();
		protected Socket _socket;
		protected CancellationTokenSource _cancellationTokenSource;

		public event EventHandler<string> OnMessageReceived;

		public SocketBase(string ip, int port)
		{
			if (string.IsNullOrWhiteSpace(ip))
				throw new ArgumentException();
			_cancellationTokenSource = new CancellationTokenSource();
			InitializeSocket(ip, port);
		}

		protected abstract void InitializeSocket(string ip, int port);

		protected void ListenMessages(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				WaitForInputData(10000, token);
				token.ThrowIfCancellationRequested();
				lock (_locker)
				{
					string msg = ReadMessage();
					OnMessageReceived?.Invoke(this, msg);
				}
			}
		}

		private void WaitForInputData(int timeoutMs, CancellationToken token)
		{
			while (_socket.Available <= 0
				&& (timeoutMs -= 10) > 0
				&& (token == null || !token.IsCancellationRequested))
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
				WaitForInputData(10000, _cancellationTokenSource.Token);
				return ReadMessage();
			}
		}
	}
}
