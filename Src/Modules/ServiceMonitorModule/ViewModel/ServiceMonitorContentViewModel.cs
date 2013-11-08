using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ApplicationStatusMonitor.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using ServiceMonitorModule.Model;

namespace ServiceMonitorModule.ViewModel
{
    public class ServiceMonitorContentViewModel : ViewModelBase, IServiceMonitorContentViewModel
    {
        private IStatusMonitorService _statusMonitorService;

        #region Commands

        public DelegateCommand<int?> StartServiceCommand { get; set; }
        public DelegateCommand<ApplicationService> StopServiceCommand { get; set; }
        public DelegateCommand<int?> RestartServiceCommand { get; set; }

        #endregion

        public ServiceMonitorContentViewModel(IStatusMonitorService statusMonitorService)
        {
            _statusMonitorService = statusMonitorService;
            LoadServices();

            StartServiceCommand = new DelegateCommand<int?>(StartService, CanStartService);
            StopServiceCommand = new DelegateCommand<ApplicationService>(StopService, CanStopService);
            RestartServiceCommand = new DelegateCommand<int?>(RestartService, CanRestartService);
        }

        public void StartService(int? index)
        {
            MessageBox.Show("StartService");
        }

        public bool CanStartService(int? index)
        {
            return true;
            //            return ApplicationServices[index.Value].Status == "Stopped";
        }

        public void StopService(ApplicationService service)
        {

            _statusMonitorService.StopService(service.ServerName, service.ServiceName);
            LoadServices();

        }

        public bool CanStopService(ApplicationService objService)
        {
            return true;
            //return ((ApplicationService)service).Status == "Running";
        }

        public void RestartService(int? index)
        {
            MessageBox.Show("RestartService");

        }

        public bool CanRestartService(int? index)
        {
            return true;
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
                    ServiceName = service.ServiceName,
                    ApplicationServiceID = service.ApplicationServiceId,
                    ServerName = service.Server.ServerName,
                    Status = service.Status,
                    StatusID = 0
                });

            }

            ApplicationServices = _applicationServices;
        }
    }
}
