using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyMVXProjCore.Model
{
    public class PushMessage
    {
        private string action;
        private string channel;
        private string message;

        public PushMessage(string actn, string chnl, string msg)
        {
            this.Action = actn;
            this.Channel = chnl;
            this.message = msg;
        }

        [JsonProperty(PropertyName ="action")]
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

        [JsonProperty(PropertyName = "message")]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

    }
}
