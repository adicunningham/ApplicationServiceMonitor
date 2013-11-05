using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationStatusMonitor.Infrastructure;
using ServiceMonitorModule.Model;

namespace ServiceMonitorModule.ViewModel
{
    public class ServiceMonitorContentViewModel : ViewModelBase, IServiceMonitorContentViewModel
    {
        private IStatusMonitorService _statusMonitorService;
        public ServiceMonitorContentViewModel(IStatusMonitorService statusMonitorService)
        {
            _statusMonitorService = statusMonitorService;
            LoadServices();
        }

        private ObservableCollection<ApplicationService> _applicationServices; 
        public ObservableCollection<Model.ApplicationService> ApplicationServices
        {
            get
            {
                return _applicationServices;
            }
            set
            {
                _applicationServices = value;
                RaisePropertyChanged("ApplicationServices");
            }
        }

        private ApplicationService _selectedService;
        public ApplicationService SelectedService
        {
            get
            {
                return _selectedService;
            }
            set
            {
                _selectedService = value;
                RaisePropertyChanged("SelectedService");
            }
        }

        public void LoadServices()
        {
            _applicationServices = new ObservableCollection<ApplicationService>();

            var appServices = _statusMonitorService.GetApplicationServices();

            foreach (var service in appServices)
            {
                _applicationServices.Add(new ApplicationService
                {
                    ApplicationName = service.ServiceName,
                    ApplicationServiceID = service.ApplicationServiceId,
                    ServerName = service.Server.ServerName,
                    Status = "Online",
                    StatusID = 0
                });

            }

            ApplicationServices = _applicationServices;
        }
    }
}
