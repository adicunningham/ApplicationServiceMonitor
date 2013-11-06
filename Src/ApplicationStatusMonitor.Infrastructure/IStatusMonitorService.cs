using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Infrastructure
{
    public interface IStatusMonitorService
    {
        IList<Server> GetServers();
        IList<Application> GetApplications();
        IList<ApplicationService> GetApplicationServices();
        string GetServiceStatus(string serverName, string serviceName);
        void StopService(string serverName, string serviceName);
        void StartService(string serverName, string serviceName);
    }
}
