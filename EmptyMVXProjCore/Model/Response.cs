using Newtonsoft.Json;
using System.Net;

namespace EmptyMVXProjCore.Model
{
    public class Response
    {
        private string message;
        private string httpStatus;

        public Response(string payld, string httpstats)
        {
            this.Message = payld;
            this.HttpStatus = httpstats;
        }

        [JsonProperty(PropertyName = "message")]
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        [JsonProperty(PropertyName ="httpStatus")]
        public string HttpStatus
        {
            get { return this.httpStatus; }
            set { this.httpStatus = value; }
        }


    }
}
