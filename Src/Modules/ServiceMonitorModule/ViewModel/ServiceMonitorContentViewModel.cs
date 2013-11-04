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
        public ServiceMonitorContentViewModel()
        {
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

            for (int i = 0; i < 10; i++)
            {
                ApplicationService service = new ApplicationService();
                service.ApplicationServiceID = i + 1;
                service.ApplicationName = string.Format("Applicastion{0}", i + 1);
                service.ServerName = "MyService";
                service.ServiceName = string.Format("Service{0}", i + 1);
                service.Status = "Online";
                service.StatusID = 1;
                _applicationServices.Add(service);
            }

            ApplicationServices = _applicationServices;
        }
    }
}
