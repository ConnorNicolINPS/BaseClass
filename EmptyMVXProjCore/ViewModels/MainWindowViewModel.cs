namespace EmptyMVXProjCore.ViewModels
{
    using MvvmCross.Core.ViewModels;

    public class MainWindowViewModel : MvxViewModel
    {
        private bool hideTaskBar;

        private MvxCommand hideButtonCommand;

        public MainWindowViewModel()
        { 
            this.HideTaskBar = true;
        }

        public bool HideTaskBar 
        {
            get { return this.hideTaskBar; }
            set { this.SetProperty(ref this.hideTaskBar, value); }
        }

        public MvxCommand HideButtonCommand
        {
            get
            {
                return this.hideButtonCommand ?? (this.hideButtonCommand = new MvxCommand(HideButtonAction));
            }
        }

        private void HideButtonAction()
        {
            HideTaskBar = !HideTaskBar;
        }
    }
}
