
namespace EmptyMVXProjCore.ViewModels
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform;

    public class FirstViewModel : MvxViewModel
    {
        private MvxCommand goToSecondViewCommand;
        private MvxCommand goToThirdViewCommand;

        private MvxNavigationService navService;

        public FirstViewModel()
        {
            this.navService = Mvx.Resolve<MvxNavigationService>();
        }

        public MvxCommand GoToSecondViewCommand
        {
            get { return this.goToSecondViewCommand ?? (this.goToSecondViewCommand = new MvxCommand(this.GoToSecondViewAction)); }
        }

        public MvxCommand GoToThirdViewCommand
        {
            get { return this.goToThirdViewCommand ?? (this.goToThirdViewCommand = new MvxCommand(this.GoToThirdViewAction)); }
        }

        private void GoToSecondViewAction()
        {
            this.navService.Navigate<SecondViewModel>();
        }

        private void GoToThirdViewAction()
        {
           this.navService.Navigate<SecondViewModel>();
        }
    }
}