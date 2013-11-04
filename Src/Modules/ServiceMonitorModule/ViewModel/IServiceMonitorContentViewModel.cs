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
    public interface IServiceMonitorContentViewModel : IViewModel
    {
        ObservableCollection<ApplicationService> ApplicationServices { get; set; } 
        ApplicationService SelectedService { get; set; }
    }
}
