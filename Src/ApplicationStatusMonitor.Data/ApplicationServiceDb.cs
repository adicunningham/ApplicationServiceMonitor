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

        public DbSet<Application> Applications { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<ApplicationService> ApplicationServices { get; set; }
    }
}
