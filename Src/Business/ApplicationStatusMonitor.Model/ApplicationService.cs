using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationStatusMonitor.Model
{
    public class ApplicationService
    {
        public int ApplicaitonServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServerName { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
    }
}
