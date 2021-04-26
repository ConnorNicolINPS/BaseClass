namespace BaseEmptyMVXProj.Core.ViewModel
{
    using MvvmCross.Core.ViewModels;

    public class FirstViewModel : MvxViewModel
    {
        private string testMessage;
        public FirstViewModel()
        {
            this.TestMessage = "this is a test message";
        }

        public string TestMessage
        {
            get { return this.testMessage; }
            set { this.SetProperty(ref this.testMessage, value); }
        }
    }
}
