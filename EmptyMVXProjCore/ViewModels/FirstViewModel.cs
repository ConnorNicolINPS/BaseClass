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
        private ICommand getStaffCommand;
        private string messageToSend;
        private string channelToSendTo;
        private string successMessage;
        private MessagingService sendService;

        public FirstViewModel()
        {
            sendService = new MessagingService();
        }

        public ICommand SendMessageCommand
        {
            get { return this.sendMessageCommand ?? (this.sendMessageCommand = new MvxCommand(SendMessage)); }
        }

        public ICommand GetStaffCommand
        {
            get { return this.getStaffCommand ?? (this.getStaffCommand = new MvxCommand(GetStaff)); }
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
    }
}
