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

        public DelegateCommand<ApplicationService> RefreshServiceCommand { get; set; }

        #endregion

        public ServiceMonitorContentViewModel(IStatusMonitorService statusMonitorService)
        {
            _statusMonitorService = statusMonitorService;
            LoadServices();

            StartServiceCommand = new DelegateCommand<ApplicationService>(StartService, CanStartService);
            StopServiceCommand = new DelegateCommand<ApplicationService>(StopService, CanStopService);
            RestartServiceCommand = new DelegateCommand<ApplicationService>(RestartService, CanRestartService);
            RefreshServiceCommand = new DelegateCommand<ApplicationService>(RefreshService);
        }


        public async void StartService(ApplicationService service)
        {
            IsBusy = true;
            var startServiceTask = Task.Factory.StartNew(() => _statusMonitorService.StartService(service.ServerName, service.ServiceName));
            await startServiceTask.ContinueWith(e =>
            {
                IsBusy = false;
                SelectedService.Status = e.Result;
                SelectedService.Image = GetImageSource(SelectedService.Status);
            });
            RaiseContextMenuCanExceute();
        }

        public bool CanStartService(ApplicationService service)
        {
            if (SelectedService.Status == "Offline")
                return false;
            return SelectedService != null && SelectedService.Status != "Running";
        }

        public async void StopService(ApplicationService service)
        {
            IsBusy = true;
            var stopServiceTask = Task.Factory.StartNew(() => _statusMonitorService.StopService(service.ServerName, service.ServiceName));
            await stopServiceTask.ContinueWith(e =>
            {
                if (e.IsCompleted)
                {
                    IsBusy = false;
                    SelectedService.Status = e.Result;
                    SelectedService.Image = GetImageSource(SelectedService.Status);
                }
            });
            

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
            SelectedService.Status = _statusMonitorService.GetServiceStatus(SelectedService.ServerName, SelectedService.ServiceName);
        }

        public bool CanRestartService(ApplicationService service)
        {
            if (SelectedService.Status == "Offline")
                return false;
            return SelectedService != null && SelectedService.Status != "Running";
        }

        public void RefreshService(ApplicationService servie)
        {
            SelectedService.Status = _statusMonitorService.GetServiceStatus(SelectedService.ServerName, SelectedService.ServiceName);
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


        public bool IsBusy { get; set; }

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

            var applications = _statusMonitorService.GetApplications();

            foreach (var app in applications)
            {
                foreach (var service in app.Services)
                {
                    _applicationServices.Add(new ApplicationService
                    {
                        ApplicationName = app.ApplicationName,
                        Environment = app.Environment.EnvironmentName,
                        ServiceName = service.ServiceName,
                        ServiceDisplayName = service.ServiceDisplayName,
                        ApplicationServiceId = service.ApplicationServiceId,
                        ServerName = service.Server.ServerName,
                        Status = service.Status,
                        Image = GetImageSource(service.Status)
                    });
                }

            }

            ApplicationServices = _applicationServices;
        }

        private string GetImageSource(string status)
        {
            switch (status)
            {
                case "Running":
                    return "Images/accept.png";
                case "Stopped":
                    return "Images/remove.png";
                default:
                    return "";
            }
        }

        private void RaiseContextMenuCanExceute()
        {
            StartServiceCommand.RaiseCanExecuteChanged();
            StopServiceCommand.RaiseCanExecuteChanged();
            RestartServiceCommand.RaiseCanExecuteChanged();
        }
    }
}
