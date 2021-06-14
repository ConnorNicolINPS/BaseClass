namespace BaseEmptyMVXProj.Core.ViewModel
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform;
    using System;

    public class ThirdViewModel : MvxViewModel
    {
        private IMvxNavigationService navService;
        private MvxCommand goToFirstViewCommand;
        private MvxCommand goToSecondViewCommand;
        private MvxCommand closeCommand;

        public ThirdViewModel(IMvxNavigationService navigationService)
        {
            this.navService = navigationService;
        }

        public MvxCommand GoToFirstViewCommand
        {
            get { return this.goToFirstViewCommand ?? (this.goToFirstViewCommand = new MvxCommand(this.GoToFirstViewAction)); }
        }
        public MvxCommand GoToSecondViewCommand
        {
            get { return this.goToSecondViewCommand ?? (this.goToSecondViewCommand = new MvxCommand(this.GoToSecondViewAction)); }
        }
        public MvxCommand CloseCommand
        {
            get { return this.closeCommand ?? (this.closeCommand = new MvxCommand(this.CloseAction)); }
        }

        private void CloseAction()
        {
            this.navService.Close(this);
        }

        private void GoToFirstViewAction()
        {
            this.navService.Navigate<FirstViewModel>();
        }

        private void GoToSecondViewAction()
        {
            this.navService.Navigate<SecondViewModel>();
        }
    }
}
