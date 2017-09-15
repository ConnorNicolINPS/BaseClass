
using Newtonsoft.Json;

namespace EmptyMVXProjCore.Models
{
    public class Region
    {
        private string system;
        private string code;
        private string display;

        public Region(string sys, string code, string display)
        {
            this.System = sys;
            this.Code = code;
            this.Display = display;
        }

        [JsonProperty("system")]
        public string System
        {
            get { return this.system; }
            set { this.system = value; }
        }

        [JsonProperty("code")]
        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        [JsonProperty("display")]
        public string Display
        {
            get { return this.display; }
            set { this.display = value; }
        }


    }
}
