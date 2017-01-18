using EmptyMVXProjCore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmptyMVXProjCore.Services
{
    class MessagingService
    {
        private const string BaseURL = "http://localhost:9090/";

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
    }
}
