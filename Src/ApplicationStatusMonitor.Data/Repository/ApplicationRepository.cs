using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data.Repository
{
    public class ApplicationRepository : Repository<Application>
    {

        public ApplicationRepository(ApplicationServiceDb context) : base(context)
        {
        }

        
        
        
    }
}
