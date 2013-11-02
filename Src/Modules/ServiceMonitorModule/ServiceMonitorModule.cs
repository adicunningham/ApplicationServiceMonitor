using System;
using ApplicationStatusMonitor.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ServiceMonitorModule.View;
using ServiceMonitorModule.ViewModel;

namespace ServiceMonitorModule
{
    public class ServiceMonitorModule : IModule
    {

        private IUnityContainer _unityContainer;
        private IRegionManager _regionManager;

        #region Constructors

        public ServiceMonitorModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;
            
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

            _unityContainer.RegisterType<IServiceMonitorContentViewModel, ServiceMonitorContentViewModel>();
            _unityContainer.RegisterType<IServiceMonitorNavigatorViewModel, ServiceMonitorNavigatorViewModel>();
            _unityContainer.RegisterType<IServiceMonitorToolbarViewModel, ServiceMonitorToolbarViewModel>();
            _unityContainer.RegisterType<IServiceMonitorTaskButtonViewModel, ServiceMonitorTaskButtonViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof (ServiceMonitorNavigatorView));
            _regionManager.RegisterViewWithRegion(RegionNames.TaskbuttonRegion, typeof (ServiceMonitorTaskButtonView));
            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof (ServiceMonitorToolbarView));
            _regionManager.RegisterViewWithRegion(RegionNames.WorkspaceRegion, typeof (ServiceMonitorContentView));
        }
    }
}
