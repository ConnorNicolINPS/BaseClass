
using Newtonsoft.Json;

namespace EmptyMVXProjCore.Models
{
    public class FakeResponse 
    {
        private string name;
        private string body;

        public FakeResponse(string name, string body)
        {
            this.Name = name;
            this.Body = body;
        }

        [JsonProperty("name")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [JsonProperty("body")]
        public string Body
        {
            get { return this.body; }
            set { this.body = value; }
        }

    }
}
