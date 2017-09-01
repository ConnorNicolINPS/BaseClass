using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmptyMVXProjCore.Services
{
    class F5Services
    {
        private const string BASEURL = "http://localhost:8080";

        HttpResponseMessage Response;
        HttpClient Client;

        public F5Services()
        {
            this.Response = new HttpResponseMessage();
            this.Client = new HttpClient();
            Client.BaseAddress = new Uri(BASEURL);
        }

        public async  Task<string> GetF5Response()
        {

            return "";
        }
    } 
}


