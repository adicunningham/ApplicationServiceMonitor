using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data
{
    public class ApplicationServiceRepository : IApplicationServiceRepository
    {
        public IList<Server> GetServers()
        {
            using (var ctx = new ApplicationServiceDb())
            {
                return ctx.Servers.ToList();
            }
        }

        public IList<ApplicationService> GetApplicationServices()
        {
            using (var ctx = new ApplicationServiceDb())
            {
                return ctx.ApplicationServices.Include(service => service.Server).ToList();
            }
        }

        public IList<Application> GetApplications()
        {
            using (var ctx = new ApplicationServiceDb())
            {
                return ctx.Applications.Include(a => a.Services.Select(s => s.Server)).ToList();
            }
        }
    }
}
