using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
	public class SocketClient: SocketBase, ISocket
	{
		public SocketClient(string ip, int port): base(ip, port) { }

		protected sealed override void InitializeSocket(string ip, int port)
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
			connectingTask.ContinueWith(t =>
			{
				ListenMessages(_cancellationTokenSource.Token);
			}, _cancellationTokenSource.Token);
			connectingTask.Wait();
		}
	}
}
