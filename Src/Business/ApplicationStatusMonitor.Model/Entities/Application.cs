using System.Collections.Generic;
using ApplicationStatusMonitor.Helper.Extensions;

namespace ApplicationStatusMonitor.Model.Entities
{
    public class Application :BaseEntity
    {

        public int ApplicationId { get; set; }

        private string _applicationName;
        public string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                _applicationName = value;
                RaisePropertyChanged("ApplicationName");
            }
        }

        private string _applicationDescription;
        public string ApplicationDescription 
        {
            get
            {
                return _applicationDescription;
            }
            set
            {
                _applicationDescription = value;
                RaisePropertyChanged("ApplicationDescription");
            }
        }

        private IList<ApplicationService> _services; 
        public IList<ApplicationService> Services 
        {
            get
            {
                return _services;
            }
            set
            {
                _services = value;
                RaisePropertyChanged("Services");
            }
        }

        private Environment _environment;
        public Environment Environment
        {
            get
            {
                return _environment;
            }
            set
            {
                _environment = value;
                RaisePropertyChanged("Environment");
            }
        }
    
    }
}
