using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationStatusMonitor.Model.Entities
{
    public class ApplicationService : BaseEntity
    {
        public int ApplicationServiceId { get; set; }
        public int ApplicationId { get; set; }

        private int? _serverId;
        [ForeignKey("Server")]
        public int? ServerId
        {
            get
            {
                return _serverId;
            }
            set
            {
                _serverId = value;
                RaisePropertyChanged("ServerId");
            }
        }

        private Server _server;

        public Server Server
        {
            get
            {
                return _server;
            }
            set
            {
                _server = value;
                RaisePropertyChanged("Server");
            }
        }

        private string _serviceName;
        public string ServiceName 
        {
            get
            {
                return _serviceName;
            }
            set
            {
                _serviceName = value;
                RaisePropertyChanged("ServiceName");
            }
        }

        private string _serviceDescription;

        public string ServiceDescription
        {
            get
            {
                return _serviceDescription;
            }
            set
            {
                _serviceDescription = value;
                RaisePropertyChanged("ServiceDescription");
            }
        }


        private string _status;
        public string Status 
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }
        
        

    }
}
