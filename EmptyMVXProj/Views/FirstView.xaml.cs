using System;
using MvvmCross.Wpf.Views;
using WebSocket4Net;
using System.Windows;

namespace EmptyMVXProj.Views
{
    public partial class FirstView : MvxWpfView
    {
        private WebSocket websocket;

        public FirstView()
        {
            this.InitializeComponent();

            websocket = new WebSocket("ws://127.0.0.1:7941");
            websocket.MessageReceived += OnMessageReceived;
        }
        private void OpenConnectionButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            websocket.Open();
        }

        private void RegisterButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ChannelTextBox.Text))
            {
                string message = $"{{\"action\":\"subscribe\", \"channel\":\"{ChannelTextBox.Text}\"}}";
                websocket.Send(message);
            }
            else
            {
                MessageBox.Show("Please enter a channel name to connect to / create", "no channel entered");
            }
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                this.ReceivedMessageTextBox.Text += e.Message;
            }));
        }

       
    }
}
