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
        ////private const string BaseURL = "http://52.31.21.118:9090/";
        private const string BaseURL = "http://172.17.186.111:9090";

        private HttpResponseMessage response;
        private HttpClient client;

        public MessagingService()
        {
            response = new HttpResponseMessage();
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseURL);
        }

        public async Task<Response> SendMessage(string Msg, string chnl)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(new PushMessage("PushMessage", chnl, Msg));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage(HttpMethod.Post, "/channel/community/shit");
                request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                response = await client.SendAsync(request).ConfigureAwait(false);

                var payload = await response.Content.ReadAsStringAsync();
                Response serviceResponse;
                try
                {
                     serviceResponse = JsonConvert.DeserializeObject<Response>(payload);
                }
                catch (Exception ex)
                {
                     serviceResponse = new Response("Error parsing data", HttpStatusCode.BadRequest);
                }

                return serviceResponse;
            }
            catch
            {
                Debug.WriteLine("failed to send message");
                return null;
            }
        }

        public async Task<bool> SendMessageToVertx(string Msg, string chnl)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(new PushMessage("PushMessage", chnl, Msg));
                response = await client.PostAsync("/v1/administration/notification", new StringContent(jsonString)).ConfigureAwait(false);

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

        public async Task SendLog()
        {
            var logRequest = new { type = "this is the type", value = "this is the value" };
            string serialisedLog = JsonConvert.SerializeObject(logRequest);
            var content = new StringContent(serialisedLog, Encoding.UTF8, "application/json");

            AddAuthHeaders();

            var response = await client.PostAsync("v1/workflow/log/", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = "Wooooooo Hoooooo";
            }
        }

        private void AddAuthHeaders()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "vision_connection token=3:2-2-3ef0d524b5f445468ec52ac6a1e74324-c29f814f0b4b41eca2538b2903beb51f");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
