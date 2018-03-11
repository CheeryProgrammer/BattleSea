using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
	public class SocketClient: SocketBase
	{
		private Task _listeningTask;

		public SocketClient(string ip, int port): base(ip, port) { }

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
					_socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
					_socket.Connect(new IPEndPoint(address, _port));
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
			_socket?.Close();
			_socket?.Dispose();
			_socket = null;
		}
	}
}
