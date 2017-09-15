using System;
using EmptyMVXProjCore.Services;
using MvvmCross.Core.ViewModels;
using EmptyMVXProjCore.Models;
using System.Collections.ObjectModel;

namespace EmptyMVXProjCore.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        //Fields
        private string responseText;
        private string fakeResponseText;
        private bool showHealthBoards;

        private MvxCommand getFakeResponseCommand;
        private MvxCommand getResponseCommand;

        private F5Services service;
        private ObservableCollection<ServiceAddress> regions;
        private ObservableCollection<ServiceAddress> healthBoards;
        private ServiceAddress selectedRegion;
        private ServiceAddress selectedHealthBoard;

        //Ctor
        public FirstViewModel()
        {
            this.ResponseText = "Fallback Value here";
            this.FakeResponseText = "Fake Fallback Value here";
            this.ShowHealthBoards = false;

            this.Service = new F5Services();
            this.Regions = new ObservableCollection<ServiceAddress>();
            this.HealthBoards = new ObservableCollection<ServiceAddress>();

        }

        //Properties 
        public string ResponseText
        {
            get { return this.responseText; }
            set { this.SetProperty(ref this.responseText, value); }
        }

        public string FakeResponseText
        {
            get { return this.fakeResponseText; }
            set { this.SetProperty(ref this.fakeResponseText, value); }
        }
        public bool ShowHealthBoards
        {
            get { return this.showHealthBoards; }
            set { this.SetProperty(ref this.showHealthBoards, value); }
        }

        public MvxCommand GetFakeResponseCommand
        {
            get { return this.getFakeResponseCommand ?? (this.getFakeResponseCommand = new MvxCommand(GetFakeReponseAction)); }
        }

        public MvxCommand GetResponseCommand
        {
            get { return this.getResponseCommand ?? (this.getResponseCommand = new MvxCommand(GetResponseAction)); }
        }

        public F5Services Service
        {
            get { return this.service; }
            set { this.SetProperty(ref this.service, value); }
        }

        public ObservableCollection<ServiceAddress> Regions
        {
            get { return this.regions; }
            set { this.SetProperty(ref this.regions, value); }
        }

        public ObservableCollection<ServiceAddress> HealthBoards
        {
            get { return this.healthBoards; }
            set { this.SetProperty(ref this.healthBoards, value); }
        }
        public ServiceAddress SelectedRegion
        {
            get { return this.selectedRegion; }
            set { this.SetProperty(ref this.selectedRegion, value); }
        }

        public ServiceAddress SelectedHealthBoard
        {
            get { return this.selectedHealthBoard; }
            set { this.SetProperty(ref this.selectedHealthBoard, value); }
        }

        //Methods
        public void RegionSelected()
        {
            if (SelectedRegion.ServiceAddressList.Count > 0)
            {
                this.HealthBoards = SelectedRegion.ServiceAddressList;
                this.ShowHealthBoards = true;
            }
            else
            {
                this.HealthBoards = new ObservableCollection<ServiceAddress>();
                this.showHealthBoards = false;
            }

            ShowUrlToUse(SelectedRegion);
         }
        public void HealthBoardSelected()
        {
            ShowUrlToUse(SelectedHealthBoard);
        }

        private async void GetFakeReponseAction()
        {
            FakeResponse response = await this.Service.GetFakeF5Response().ConfigureAwait(false);

            this.FakeResponseText = string.Format($"Response received!: \n Name: {response.Name} \n Body: {response.Body}");
        }

        private async void GetResponseAction()
        {
            ObservableCollection<ServiceAddress> allServices = await this.service.GetRealF5Response().ConfigureAwait(false);
            if (allServices != null)
            {
                this.Regions = allServices;
                return;
            }

            this.ResponseText = "There was an issue getting or parsing the data";
        }
        private void ShowUrlToUse(ServiceAddress service)
        {
            if (service.Fqdns != null)
            {
                this.ResponseText = $"Region selected! \n please user the URL: {service.Fqdns}";
            }
        }
    }
}
