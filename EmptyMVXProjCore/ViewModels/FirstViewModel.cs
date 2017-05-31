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
        private ICommand getStaffCommand;
        private ICommand sendLogCommand;
        private ICommand openConnectionCommand;
        private ICommand registerChannelCommand;

        private string messageToSend;
        private string channelToSendTo;
        private string successMessage;
        private string receivedMessage;
        private string connectionStatus;

        private MessagingService sendService;
        private IWebSocketHandler webSocketHandler;


        public FirstViewModel()
        {
            sendService = new MessagingService();

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

        public ICommand GetStaffCommand
        {
            get { return this.getStaffCommand ?? (this.getStaffCommand = new MvxCommand(GetStaff)); }
        }

        public ICommand SendLogCommand
        {
            get { return this.sendLogCommand ?? (this.sendLogCommand = new MvxCommand(SendLogs)); }
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

        public string SuccessMessage
        {
            get { return this.successMessage; }
            set { this.SetProperty(ref this.successMessage, value); }
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

        private async void GetStaff()
        {
            var success = await sendService.GetStaff();

            if (success)
            {
                successMessage = "WOOOOOOO HOOOOOOO SUCCESS!!!!!!";
            }
            else
            {
                successMessage = "SAD FACE :,( didnt work!!!";
            }
        }

        private async void SendLogs()
        {
            await sendService.SendLog();
        }

        private void OpenConnection()
        {
            this.webSocketHandler.OpenConnection();
            this.ConnectionStatus = this.webSocketHandler.GetConnectionStatus();
        }

        private void RegisterChannel()
        {
            string registerMessage = JsonConvert.SerializeObject( new PushMessage("subscribe", this.ChannelToSendTo, string.Empty));
            this.webSocketHandler.RegisterChannel(registerMessage);
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
