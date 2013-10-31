using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ServiceMonitorModule.View;
using ServiceMonitorModule.ViewModel;

namespace ServiceMonitorModule
{
    public class ServiceMonitorModule : IModule
    {

        private IUnityContainer _unityContainer;

        #region Constructors

        public ServiceMonitorModule(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        #endregion

        public void Initialize()
        {
            RegisterTypes();
        }

        private void RegisterTypes()
        {
            _unityContainer.RegisterType<ServiceMonitorToolbarView>();
            _unityContainer.RegisterType<ServiceMonitorNavigatorView>();
            _unityContainer.RegisterType<ServiceMonitorTaskButtonView>();
            _unityContainer.RegisterType<ServiceMonitorContentView>();

            //_unityContainer.RegisterType<IServiceMonitorContentViewModel, Service
        }
    }
}
