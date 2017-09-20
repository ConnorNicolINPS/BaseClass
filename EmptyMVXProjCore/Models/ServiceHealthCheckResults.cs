namespace EmptyMVXProjCore.Models
{
    public class ServiceHealthCheckResults
    {
        private string serviceName;
        private bool status;

        public ServiceHealthCheckResults(string servName, bool status)
        {
            this.ServiceName = servName;
            this.Status = status;
        }

        public string ServiceName
        {
            get { return this.serviceName; }
            set { this.serviceName = value; }
        }
        public bool Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

    }
}
