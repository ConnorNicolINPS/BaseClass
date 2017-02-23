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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "vision_connection token=3:2-2-923ce513d816459692645844e2a43e1e-1fef67f4b8804f15aab1dfc922ea0849");
            ////client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            ////client.DefaultRequestHeaders.Add("X-Target-Organisation", "{{TargetOrganisation}}");
            ////client.DefaultRequestHeaders.Add("X-Business-TransactionId", "123123");
        }
    }
}
