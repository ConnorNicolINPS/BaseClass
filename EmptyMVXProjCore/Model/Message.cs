using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyMVXProjCore.Model
{
    class TheMessage
    {
        private string action;
        private string channel;
        private string message;

        public TheMessage(string act, string msg, string chnl)
        {
            this.Action = act;
            this.Channel = chnl;
            this.Message = msg;
        }

        [JsonProperty(PropertyName = "action")]
        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        [JsonProperty(PropertyName = "channel")]
        public string Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        [JsonProperty(PropertyName ="message")]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        

    }
}
