namespace EmptyMVXProjCore.ViewModels
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform;

    public class ThirdViewModel : MvxViewModel
    {
        private MvxCommand goToFirstViewCommand;
        private MvxCommand goToSecondViewCommand;

        private MvxNavigationService navService;

        public ThirdViewModel()
        {
            this.navService = Mvx.Resolve<MvxNavigationService>();
        }

        public MvxCommand GoToFirstViewCommand
        {
            get { return this.goToFirstViewCommand ?? (this.goToFirstViewCommand = new MvxCommand(this.GoToFirstViewAction)); }
        }

        public MvxCommand GoToSecondViewCommand
        {
            get { return this.goToSecondViewCommand ?? (this.goToSecondViewCommand = new MvxCommand(this.GoToSecondViewAction)); }
        }

        private void GoToFirstViewAction()
        {
            this.navService.Navigate<SecondViewModel>();
        }

        private void GoToSecondViewAction()
        {
            this.navService.Navigate<SecondViewModel>();
        }
    }
}
