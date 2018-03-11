using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
	public class SocketServer: SocketBase
	{
		private Socket _listenerSock;
		private Task _listeningTask;

		public SocketServer(string ip, int port): base(ip, port) { }

		public sealed override Task<bool> InitializeSocket()
		{
			_cancellationTokenSource.Cancel();
			_cancellationTokenSource = new CancellationTokenSource();
			var connectingTask = Task.Run(() =>
			{
				try
				{
					var hostEntry = Dns.GetHostEntry(_ip);
					var address = hostEntry.AddressList[0];
					_listenerSock = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
					_listenerSock.Bind(new IPEndPoint(address, _port));
					_listenerSock.Listen(2);
					_socket = _listenerSock.Accept();
					return true;
				}
				catch
				{
					// ignored
				}
				return false;
			});
			_listeningTask = connectingTask.ContinueWith(t =>
			{
				ListenMessages(_cancellationTokenSource.Token);
			}, _cancellationTokenSource.Token);
			return connectingTask;
		}

		public override void Dispose()
		{
			_cancellationTokenSource.Cancel();
			_cancellationTokenSource = null;
			_listenerSock?.Close();
			_listenerSock?.Dispose();
			_socket?.Close();
			_socket?.Dispose();
			_socket = _listenerSock = null;
		}
	}
}
