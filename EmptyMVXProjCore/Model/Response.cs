using Newtonsoft.Json;
using System.Net;

namespace EmptyMVXProjCore.Model
{
    public class Response
    {
        private string payload;
        private HttpStatusCode httpStatus;

        public Response(string payld, HttpStatusCode httpstats)
        {
            this.Payload = payld;
            this.HttpStatus = httpstats;
        }

        [JsonProperty(PropertyName = "payload")]
        public string Payload
        {
            get { return this.payload; }
            set { this.payload = value; }
        }

        [JsonProperty(PropertyName ="httpStatus")]
        public HttpStatusCode HttpStatus
        {
            get { return this.httpStatus; }
            set { this.httpStatus = value; }
        }


    }
}
