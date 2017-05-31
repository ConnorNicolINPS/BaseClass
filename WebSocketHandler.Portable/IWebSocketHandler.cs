using System;

namespace WebSocketHandler
{
    public interface IWebSocketHandler
    {
        void InitWebSocket();

        void OpenConnection();

        bool RegisterChannel(string subscribeMessage);

        string GetConnectionStatus();

        event EventHandler<string> OnMessageRecived;
        event EventHandler<string> SocketOpened;
    }
}
