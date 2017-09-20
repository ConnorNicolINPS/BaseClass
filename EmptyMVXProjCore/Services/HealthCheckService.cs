
using EmptyMVXProjCore.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmptyMVXProjCore.Services
{
    public  class HealthCheckService
    {
        private  HttpClient client = new HttpClient();
        private  HttpResponseMessage response;

        public HealthCheckService()
        {
            client = new HttpClient( new HttpClientHandler { ClientCertificateOptions = ClientCertificateOption.Automatic });
            response = new HttpResponseMessage();
        }   

        public  async Task<bool> HealthCheck(string clientUrl)
        {
            try
            {
                client.BaseAddress = new Uri(clientUrl);
                response = await client.GetAsync(Constants.HEALTH_CHECK_URL).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
