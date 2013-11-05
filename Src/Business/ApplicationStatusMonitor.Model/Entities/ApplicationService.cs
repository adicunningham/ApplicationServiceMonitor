using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationStatusMonitor.Model.Entities
{
    public class ApplicationService : BaseEntity
    {
        public int ApplicationServiceId { get; set; }
        public int ApplicationId { get; set; }
        
        [ForeignKey("Server")]
        public int? ServerId { get; set; }
        public Server Server { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        

    }
}
