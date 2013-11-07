using System.Collections.Generic;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data
{
    public interface IApplicationServiceRepository
    {
        IList<Server> GetServers();
        IList<ApplicationService> GetApplicationServices();
        IList<Application> GetApplications();
    }
}
