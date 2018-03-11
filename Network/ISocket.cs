using System;
using System.Threading.Tasks;

namespace Network
{
	public interface ISocket: IDisposable
	{
		event EventHandler<string> OnMessageReceived;
		void Send(string v);
		string Request(string v);
		Task<bool> InitializeSocket();
	}
}
