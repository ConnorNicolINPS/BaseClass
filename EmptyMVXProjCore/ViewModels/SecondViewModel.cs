

namespace EmptyMVXProjCore.ViewModels
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform;

    public class SecondViewModel : MvxViewModel
    {
        private MvxCommand goToFirstViewCommand;
        private MvxCommand goToThirdViewCommand;

        private MvxNavigationService navService;

        public SecondViewModel()
        {
            this.navService = Mvx.Resolve<MvxNavigationService>();
        }

        public MvxCommand GoToFirstViewCommand
        {
            get { return this.goToFirstViewCommand ?? (this.goToFirstViewCommand = new MvxCommand(this.GoToFirstViewAction)); }
        }

        public MvxCommand GoToThirdViewCommand
        {
            get { return this.goToThirdViewCommand ?? (this.goToThirdViewCommand = new MvxCommand(this.GoToThirdViewAction)); }
        }

        private void GoToFirstViewAction()
        {
            this.navService.Navigate<FirstViewModel>();
        }

        private void GoToThirdViewAction()
        {
            this.navService.Navigate<SecondViewModel>();
        }
    }
}
