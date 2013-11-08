using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationStatusMonitor.Model.Entities
{
    public class ServiceType : BaseEntity
    {
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
    }
}
