namespace BaseEmptyMVXProj.Core.ViewModel
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class SecondViewModel : MvxViewModel
    {
        private IMvxNavigationService navService;
        private MvxCommand goToFirstViewCommand;
        private MvxCommand goToThirdViewCommand;

        private ObservableCollection<string> testList;
        private string selectedListItem;

        public SecondViewModel(IMvxNavigationService navigationService)
        {
            this.navService = navigationService;
            this.TestList = new ObservableCollection<string>();

            this.TestList.Add("TestItem 1");
            this.TestList.Add("TestItem 2");
            this.TestList.Add("TestItem 3");
            this.TestList.Add("TestItem 4");
            this.TestList.Add("TestItem 5");
            this.TestList.Add("TestItem 6");
            this.TestList.Add("TestItem 7");
            this.TestList.Add("TestItem 8");
            this.TestList.Add("TestItem 9");
            this.TestList.Add("TestItem 10");
            this.TestList.Add("TestItem 11");
            this.TestList.Add("TestItem 12");
            this.TestList.Add("TestItem 13");
            this.TestList.Add("TestItem 14");
            this.TestList.Add("TestItem 15");
            this.TestList.Add("TestItem 16");
            this.TestList.Add("TestItem 17");
            this.TestList.Add("TestItem 18");
            this.TestList.Add("TestItem 19");
            this.TestList.Add("TestItem 20");
            this.TestList.Add("TestItem 21");
            this.TestList.Add("TestItem 22");
            this.TestList.Add("TestItem 23");
            this.TestList.Add("TestItem 24");
            this.TestList.Add("TestItem 25");
            this.TestList.Add("TestItem 26");
            this.TestList.Add("TestItem 27");
            this.TestList.Add("TestItem 28");
            this.TestList.Add("TestItem 29");
            this.TestList.Add("TestItem 30");
        }

        public MvxCommand GoToFirstViewCommand
        {
            get { return this.goToFirstViewCommand ?? (this.goToFirstViewCommand = new MvxCommand(this.GoToFirstViewAction)); }
        }
        public MvxCommand GoToThirdViewCommand
        {
            get { return this.goToThirdViewCommand ?? (this.goToThirdViewCommand = new MvxCommand(this.GoToThirdViewAction)); }
        }
        public ObservableCollection<string> TestList
        {
            get { return this.testList; }
            set { this.SetProperty(ref this.testList, value); }
        }
        public string SelectedListItem
        {
            get { return this.selectedListItem; }
            set { this.SetProperty(ref this.selectedListItem, value); }
        }

        private void GoToFirstViewAction()
        {
            this.navService.Navigate<FirstViewModel>();
        }

        private void GoToThirdViewAction()
        {
            this.navService.Navigate<ThirdViewModel>();
        }
    }
}
