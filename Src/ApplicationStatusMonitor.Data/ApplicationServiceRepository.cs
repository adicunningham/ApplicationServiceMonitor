using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data
{
    public class ApplicationServiceRepository : IApplicationServiceRepository
    {
        private Repository<ApplicationServiceDb> _repository;

        public ApplicationServiceRepository()
        {
            
        }

        public IList<Server> GetServers()
        {
            
            using (var ctx = new ApplicationServiceDb())
            {
                return ctx.Server.ToList();
            }
        }

        public IList<ApplicationService> GetApplicationServices()
        {
            using (var ctx = new ApplicationServiceDb())
            {
                return ctx.ApplicationService.Include(service => service.Server).ToList();
            }
        }

        public IList<Application> GetApplications()
        {
            using (var ctx = new ApplicationServiceDb())
            {
                return ctx.Application.Include(a => a.Services.Select(s => s.Server)).ToList();
            }
        }
    }
}
