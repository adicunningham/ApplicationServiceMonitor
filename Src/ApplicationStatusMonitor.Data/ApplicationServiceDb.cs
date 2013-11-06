using System.Configuration;
using System.Data.Entity;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data
{
    internal class ApplicationServiceDb : DbContext
    {
        public ApplicationServiceDb()
            : base(ConfigurationManager.ConnectionStrings["ApplicationStatusDb"].ConnectionString)
        {
            
        }

        public DbSet<Application> Application { get; set; }
        public DbSet<Server> Server { get; set; }
        public DbSet<ApplicationService> ApplicationService { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
    }
}
