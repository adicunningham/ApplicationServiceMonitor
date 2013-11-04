namespace ServiceMonitorModule.Model
{
    public class ApplicationService
    {
        public int ApplicationServiceID { get; set; }
        public string ApplicationName { get; set; }
        public string ServiceName { get; set; }
        public string ServerName { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
    }
}
