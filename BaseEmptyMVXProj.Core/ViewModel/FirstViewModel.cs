namespace BaseEmptyMVXProj.Core.ViewModel
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform;

    public class FirstViewModel : MvxViewModel
    {
        private IMvxNavigationService navService;
        private MvxCommand goToSecondViewCommand;
        private MvxCommand goToThirdViewCommand;

        private string enteredText;

        public FirstViewModel(IMvxNavigationService navigationService)
        {
            this.navService = navigationService;
        }

        public MvxCommand GoToSecondViewCommand
        {
            get { return this.goToSecondViewCommand ?? (this.goToSecondViewCommand = new MvxCommand(this.GoToSecondViewAction)); }
        }
        public MvxCommand GoToThirdViewCommand
        {
            get { return this.goToThirdViewCommand ?? (this.goToThirdViewCommand = new MvxCommand(this.GoToThirdViewAction)); }
        }
        public string EnteredText
        {
            get { return this.enteredText; }
            set { this.SetProperty(ref this.enteredText, value); }
        }

        private void GoToSecondViewAction()
        {
            this.navService.Navigate<SecondViewModel>();
        }

        private void GoToThirdViewAction()
        {
            this.navService.Navigate<ThirdViewModel>();
        }
    }
}
