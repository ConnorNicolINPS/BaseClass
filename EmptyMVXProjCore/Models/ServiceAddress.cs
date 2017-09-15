using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyMVXProjCore.Models
{
    public class ServiceAddress
    {
        private Region region;
        private string fqdns;
        private ObservableCollection<ServiceAddress> serviceAddressList;

        public ServiceAddress(Region reg, string fqdns = null)
        {
            this.Region = reg;
            this.fqdns = fqdns;
            this.ServiceAddressList = new ObservableCollection<ServiceAddress>();
        }

        [JsonProperty("region")]
        public Region Region
        {
            get { return this.region; }
            set { this.region = value; }
        }
        
        [JsonProperty("fqdns")]
        public string Fqdns
        {
            get { return this.fqdns; }
            set { this.fqdns = value; }
        }

        [JsonProperty("serviceAddressList")]
        public ObservableCollection<ServiceAddress> ServiceAddressList
        {
            get { return this.serviceAddressList; }
            set { this.serviceAddressList = value; }
        }
    }
}
