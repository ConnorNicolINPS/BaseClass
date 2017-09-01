using MvvmCross.Core.ViewModels;

namespace EmptyMVXProjCore.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private string responseText;

        public FirstViewModel()
        {

        }

        public string ResponseText
        {
            get { return this.responseText; }
            set { this.SetProperty(ref this.responseText, value); }
        }

    }
}
