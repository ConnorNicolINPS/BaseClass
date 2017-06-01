namespace WebSocketHandler.Wpf
{
    using System;
    using WebSocket4Net;

    public class WebSocketHandler : IWebSocketHandler
    {
        ////private const string WEBSOCKETURL = "ws://52.31.21.118:7941/";
        ////private const string WEBSOCKETURL = "ws://172.17.186.222:7941/";
        private const string WEBSOCKETURL = "ws://localhost:9090/ws-websocket";

        public event EventHandler<string> OnMessageRecived;
        public event EventHandler<string> SocketOpened;

        private WebSocket webSocket;

        public WebSocket WebSocket
        {
            get { return webSocket; }
            set { webSocket = value; }
        }

        public void InitWebSocket()
        {
            this.WebSocket = new WebSocket(WEBSOCKETURL);
            this.webSocket.MessageReceived += WebSocket_MessageReceived;
            this.WebSocket.Opened += WebSocket_Opened;
        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {
            this.SocketOpened.Invoke(this, e.ToString());
        }

        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            this.OnMessageRecived.Invoke(this, e.Message);
        }

        public string GetConnectionStatus()
        {
            return this.WebSocket.State.ToString();
        }

        public void OpenConnection()
        {
            this.WebSocket.Open();
        }

        public bool RegisterChannel(string subscribeMessage)
        {
            if (webSocket.State == WebSocketState.Open)
            {
                this.WebSocket.Send(subscribeMessage);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}