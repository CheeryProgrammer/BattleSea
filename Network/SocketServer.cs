using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
	public class SocketServer: SocketBase
	{
		public SocketServer(string ip, int port): base(ip, port) { }

		public sealed override Task<bool> InitializeSocket()
		{
			_cancellationTokenSource.Cancel();
			_cancellationTokenSource = new CancellationTokenSource();
			var listeningTask = Task.Run(() =>
			{
				try
				{
					var hostEntry = Dns.GetHostEntry(_ip);
					var address = hostEntry.AddressList[0];
					var _listenerSock = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
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
			listeningTask.ContinueWith(t =>
			{
				ListenMessages(_cancellationTokenSource.Token);
			}, _cancellationTokenSource.Token);
			return listeningTask;
		}
	}
}
