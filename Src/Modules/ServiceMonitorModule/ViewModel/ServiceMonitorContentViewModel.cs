using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ApplicationStatusMonitor.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using ServiceMonitorModule.Model;

namespace ServiceMonitorModule.ViewModel
{
    public class ServiceMonitorContentViewModel : ViewModelBase, IServiceMonitorContentViewModel
    {
        private IStatusMonitorService _statusMonitorService;

        #region Commands

        public DelegateCommand<ApplicationService> StartServiceCommand { get; set; }
        public DelegateCommand<ApplicationService> StopServiceCommand { get; set; }
        public DelegateCommand<ApplicationService> RestartServiceCommand { get; set; }

        #endregion

        public ServiceMonitorContentViewModel(IStatusMonitorService statusMonitorService)
        {
            _statusMonitorService = statusMonitorService;
            LoadServices();

            StartServiceCommand = new DelegateCommand<ApplicationService>(StartService, CanStartService);
            StopServiceCommand = new DelegateCommand<ApplicationService>(StopService, CanStopService);
            RestartServiceCommand = new DelegateCommand<ApplicationService>(RestartService, CanRestartService);
        }


        public void StartService(ApplicationService service)
        {
            SelectedService.Status = _statusMonitorService.StartService(service.ServerName, service.ServiceName);
            RaiseContextMenuCanExceute();
        }

        public bool CanStartService(ApplicationService service)
        {
            if (SelectedService.Status == "Offline")
                return false;
            return SelectedService != null && SelectedService.Status != "Running";
        }

        public void StopService(ApplicationService service)
        {
            SelectedService.Status = _statusMonitorService.StopService(service.ServerName, service.ServiceName);
            RaiseContextMenuCanExceute();
        }

        public bool CanStopService(ApplicationService service)
        {
            if (SelectedService.Status == "Offline")
                return false;
            return SelectedService != null && SelectedService.Status == "Running";
        }

        public void RestartService(ApplicationService servie)
        {
            MessageBox.Show("RestartService");
            RaiseContextMenuCanExceute();

        }

        public bool CanRestartService(ApplicationService service)
        {
            if (SelectedService.Status == "Offline")
                return false;
            return SelectedService != null && SelectedService.Status != "Running";
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


        private int? _selectedIndex;
        public int? SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
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
                RaiseContextMenuCanExceute();
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
                    ApplicationServiceId = service.ApplicationServiceId,
                    ServerName = service.Server.ServerName,
                    Status = service.Status,
                });

            }

            ApplicationServices = _applicationServices;
        }

        private void RaiseContextMenuCanExceute()
        {
            StartServiceCommand.RaiseCanExecuteChanged();
            StopServiceCommand.RaiseCanExecuteChanged();
            RestartServiceCommand.RaiseCanExecuteChanged();
        }
    }
}
