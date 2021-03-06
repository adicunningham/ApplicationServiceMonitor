﻿using ApplicationStatusMonitor.Model.Entities;

namespace ServiceMonitorModule.Model
{
    public class ApplicationService : BaseEntity
    {
        private int _applicationServiceId;
        public int ApplicationServiceId
        {
            get
            {
                return _applicationServiceId;
            }
            set
            {
                _applicationServiceId = value;
                RaisePropertyChanged("ApplicationServiceId");
            }
        }

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

        private string _serviceDisplayName;
        public string ServiceDisplayName
        {
            get
            {
                return _serviceDisplayName;
            }
            set
            {
                _serviceDisplayName = value;
                RaisePropertyChanged("ServiceDisplayName");
            }
        }


        private string _serverName;
        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                _serverName = value;
                RaisePropertyChanged("ServerName");
            }
        }

        private string _environment;
        public string Environment
        {
            get
            {
                return _environment;
            }
            set
            {
                _environment = value;
                RaisePropertyChanged("Status");
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

        private string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                RaisePropertyChanged("Image");
            }
        }

    }
}
