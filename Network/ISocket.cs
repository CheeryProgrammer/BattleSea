using System;

namespace Network
{
	public interface ISocket
	{
		event EventHandler<string> OnMessageReceived;
		void Send(string v);
		string Request(string v);
	}
}
