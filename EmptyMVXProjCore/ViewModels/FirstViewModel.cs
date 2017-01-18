using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using System;
using EmptyMVXProjCore.Services;
using System.Windows;

namespace EmptyMVXProjCore.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private ICommand sendMessageCommand;
        private string messageToSend;
        private string channelToSendTo;
        private MessagingService sendService;

        public FirstViewModel()
        {
            sendService = new MessagingService();
        }

        public ICommand SendMessageCommand
        {
            get { return this.sendMessageCommand ?? (this.sendMessageCommand = new MvxCommand(SendMessage)); }
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
    }
}
