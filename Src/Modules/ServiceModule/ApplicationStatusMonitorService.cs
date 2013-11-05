using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationStatusMonitor.Data;
using ApplicationStatusMonitor.Infrastructure;
using ApplicationStatusMonitor.Model.Entities;

namespace ServiceModule
{
    public class ApplicationStatusMonitorService : IStatusMonitorService
    {
        private IApplicationServiceRepository _serviceRepository;

        public ApplicationStatusMonitorService(IApplicationServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IList<Server> GetServers()
        {
            return _serviceRepository.GetServers();
        }

        public IList<ApplicationService> GetApplicationServices()
        {
            return _serviceRepository.GetApplicationServices();
        }

        public IList<Application> GetApplications()
        {
            return _serviceRepository.GetApplications();
        }
    }
}
