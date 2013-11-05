using System.Collections.Generic;

namespace ApplicationStatusMonitor.Model.Entities
{
    public class Application :BaseEntity
    {

        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationDescription { get; set; }
        public IList<ApplicationService> Services { get; set; }
    }
}
