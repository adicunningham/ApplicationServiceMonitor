using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationStatusMonitor.Data;
using ApplicationStatusMonitor.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace ServiceModule
{
    public class ServiceModule : IModule
    {
        private IUnityContainer _container;

        public ServiceModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IUnitOfWork, UnitOfWork>();
            _container.RegisterType<IStatusMonitorService, ApplicationStatusMonitorService>();
        }
    }
}
