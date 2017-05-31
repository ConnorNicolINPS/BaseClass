using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using System;
using EmptyMVXProjCore.Services;
using System.Windows;
using Newtonsoft.Json;
using EmptyMVXProjCore.Model;
using WebSocketHandler;
using MvvmCross.Platform;

namespace EmptyMVXProjCore.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private ICommand sendMessageCommand;
        private ICommand openConnectionCommand;
        private ICommand registerChannelCommand;

        private string messageToSend;
        private string channelToSendTo;
        private string receivedMessage;
        private string connectionStatus;
        private string registeredToAChannel;

        private MessagingService sendService;
        private IWebSocketHandler webSocketHandler;


        public FirstViewModel()
        {
            sendService = new MessagingService();

            RegisteredToAChannel = "Not registered";

            this.webSocketHandler = Mvx.Resolve<IWebSocketHandler>();

            this.webSocketHandler.InitWebSocket();
            this.webSocketHandler.OnMessageRecived += WebSocketHandler_OnMessageRecived;
            this.webSocketHandler.SocketOpened += WebSocketHandler_SocketOpened;

            this.ConnectionStatus = this.webSocketHandler.GetConnectionStatus();
        }

        #region properties
        public ICommand SendMessageCommand
        {
            get { return this.sendMessageCommand ?? (this.sendMessageCommand = new MvxCommand(SendMessage)); }
        }

        public ICommand OpenConnectionCommand
        {
            get{ return this.openConnectionCommand ?? (this.openConnectionCommand = new MvxCommand(OpenConnection)); }
        }
        public ICommand RegisterChannelCommand
        {
            get { return this.registerChannelCommand ?? (registerChannelCommand = new MvxCommand(RegisterChannel)); }
        }

        public string MessageToSend
        {
            get { return this.messageToSend; }
            set { this.SetProperty(ref this.messageToSend, value); }
        }
        public string ChannelToSendTo
        {
            get { return this.channelToSendTo; }
            set { this.SetProperty(ref this.channelToSendTo, value); }
        }

        public string ReceivedMessage
        {
            get { return this.receivedMessage; }
            set { this.SetProperty ( ref this.receivedMessage,value); }
        }
        public string ConnectionStatus
        {
            get { return this.connectionStatus; }
            set { this.SetProperty(ref this.connectionStatus, value); }
        }

        public string RegisteredToAChannel
        {
            get{ return this.registeredToAChannel; }
            set { this.SetProperty(ref this.registeredToAChannel, value); }
        }
        #endregion

        #region Methods
        private async void SendMessage()
        {
            if (this.MessageToSend != null)
            {
                var success = await sendService.SendMessage(this.messageToSend, this.ChannelToSendTo).ConfigureAwait(false);
            }
            else
            {
                MessageBox.Show("please enter some text to send", "no message entered");
            }
        }

        private void OpenConnection()
        {
            this.webSocketHandler.OpenConnection();
            this.ConnectionStatus = this.webSocketHandler.GetConnectionStatus();
        }

        private void RegisterChannel()
        {
            string registerMessage = JsonConvert.SerializeObject( new PushMessage("subscribe", this.ChannelToSendTo, string.Empty));
            if (this.webSocketHandler.RegisterChannel(registerMessage))
            {
                RegisteredToAChannel = "Registered to channel: " + ChannelToSendTo;
            }
        }

        private void WebSocketHandler_OnMessageRecived(object sender, string message)
        {
            this.ReceivedMessage += message + "\n";
        }
        private void WebSocketHandler_SocketOpened(object sender, string e)
        {
            this.ConnectionStatus = this.webSocketHandler.GetConnectionStatus();
        }


        #endregion
    }
}
