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
	public class SocketServer: SocketBase, ISocket
	{
		public SocketServer(string ip, int port): base(ip, port) { }

		protected sealed override void InitializeSocket(string ip, int port)
		{
			_cancellationTokenSource.Cancel();
			_cancellationTokenSource = new CancellationTokenSource();
			var listeningTask = Task.Run(() =>
			{
				var hostEntry = Dns.GetHostEntry(ip);
				var address = hostEntry.AddressList[0];
				var _listenerSock = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				_listenerSock.Bind(new IPEndPoint(address, port));
				_listenerSock.Listen(2);
				_socket = _listenerSock.Accept();
			});
			listeningTask.ContinueWith(t =>
			{
				ListenMessages(_cancellationTokenSource.Token);
			}, _cancellationTokenSource.Token);
			listeningTask.Wait();
		}
	}
}
