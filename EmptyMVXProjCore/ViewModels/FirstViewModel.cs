using EmptyMVXProjCore.Models;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System;
using EmptyMVXProjCore.Utils;
using EmptyMVXProjCore.Services;

namespace EmptyMVXProjCore.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private ObservableCollection<ServiceHealthCheckResults> healthCheckResults;
        private ObservableCollection<string> services;

        private MvxCommand healthCheckCommand;

        public FirstViewModel()
        {
            this.HealthCheckResults = new ObservableCollection<ServiceHealthCheckResults>();
            this.Services = new ObservableCollection<string>();
            this.InitServices();
        }

        public ObservableCollection<ServiceHealthCheckResults> HealthCheckResults
        {
            get { return this.healthCheckResults; }
            set { this.SetProperty(ref this.healthCheckResults, value); }
        }
        public ObservableCollection<string> Services
        {
            get { return this.services; }
            set { this.SetProperty(ref this.services, value); }
        }
        public MvxCommand HealthCheckCommand
        {
            get { return healthCheckCommand ?? (this.healthCheckCommand = new MvxCommand(HealthCheckAction)); }
        }

        private void InitServices()
        {
            this.Services.Add(Constants.NONSECURE_PROTOCOL + "inpsol08.is.inps.co.uk");
            this.Services.Add(Constants.NONSECURE_PROTOCOL + "inpsespc222.is.inps.co.uk");
            this.Services.Add(Constants.SECURE_PROTOCOL + "vs006.inps.co.uk");
            this.Services.Add(Constants.SECURE_PROTOCOL + "vs007.inps.co.uk");
        }

        private async void HealthCheckAction()
        {
            ObservableCollection<ServiceHealthCheckResults> tempCollection = new ObservableCollection<ServiceHealthCheckResults>();
            
            foreach (string service in this.Services)
            {
                HealthCheckService hcService = new HealthCheckService();
                ServiceHealthCheckResults result = new ServiceHealthCheckResults(service, await hcService.HealthCheck(service).ConfigureAwait(false));
                tempCollection.Add(result);
            }

            this.HealthCheckResults = tempCollection;
        }
    }
}
