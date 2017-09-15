using EmptyMVXProjCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmptyMVXProjCore.Services
{
    public class F5Services
    {
        private const string BASEURL = "https://vs007.inps.co.uk/";

        HttpResponseMessage Response;
        HttpClient Client;

        public F5Services()
        {
            this.Response = new HttpResponseMessage();
            this.Client = new HttpClient();
            Client.BaseAddress = new Uri(BASEURL);
        }

        public async  Task<FakeResponse> GetFakeF5Response()
        {
            try
            {
                this.Response = await this.Client.GetAsync("FakeF5Response").ConfigureAwait(false);

                if (this.Response.IsSuccessStatusCode)
                {
                    FakeResponse content = JsonConvert.DeserializeObject<FakeResponse>(await Response.Content.ReadAsStringAsync());
                    return content;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ObservableCollection<ServiceAddress>> GetF5Response()
        {
            try
            {
                this.Response = await this.Client.GetAsync("F5Response").ConfigureAwait(false);

                if (this.Response.IsSuccessStatusCode)
                {
                    ObservableCollection<ServiceAddress> services = JsonConvert.DeserializeObject<ObservableCollection<ServiceAddress>>(await this.Response.Content.ReadAsStringAsync());
                    return services;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ObservableCollection<ServiceAddress>> GetRealF5Response()
        {
            try
            {
                this.Response = await this.Client.GetAsync("v1/meta/serviceAddresses").ConfigureAwait(false);

                if (this.Response.IsSuccessStatusCode)
                {
                    ObservableCollection<ServiceAddress> services = JsonConvert.DeserializeObject<ObservableCollection<ServiceAddress>>(await this.Response.Content.ReadAsStringAsync());
                    return services;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}


