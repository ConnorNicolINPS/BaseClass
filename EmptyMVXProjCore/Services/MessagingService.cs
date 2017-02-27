using EmptyMVXProjCore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmptyMVXProjCore.Services
{
    class MessagingService
    {
        ////private const string BaseURL = "http://localhost:9090/";
        ////private const string BaseURL = "http://172.17.186.222:9090/";
        private const string BaseURL = "http://52.31.21.118:9090/";

        private HttpResponseMessage response;
        private HttpClient client;

        public MessagingService()
        {
            response = new HttpResponseMessage();
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseURL);
        }

        public async Task<bool> SendMessage(string Msg, string chnl)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(new TheMessage(Msg, chnl));
                response = await client.PostAsync("v1.0/dbg/notification", new StringContent(jsonString)).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                Debug.WriteLine("failed to send message");
                return false;
            }
        }

        public async Task<bool> GetStaff()
        {
            try
            {
                AddAuthHeaders();
                response = await client.GetAsync("v1.0/staff").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine("failed to get staff  error: " + e);
                return false;
            }

        }

        private void AddAuthHeaders()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "vision_connection token=3:2-2-346a74f648d2439db200395f17c141e8-645d33fd6d9c46b89ba065cea76cc81b");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
