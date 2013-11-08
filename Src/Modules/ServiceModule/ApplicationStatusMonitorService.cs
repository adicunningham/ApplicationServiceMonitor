using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Hosting;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ApplicationStatusMonitor.Data;
using ApplicationStatusMonitor.Data.UnitOfWork;
using ApplicationStatusMonitor.Infrastructure;
using ApplicationStatusMonitor.Model.Entities;

namespace ServiceModule
{
    public class ApplicationStatusMonitorService : IStatusMonitorService
    {
        private IUnitOfWork _unitOfWork;
        private ServiceController _serviceController;

        public ApplicationStatusMonitorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _serviceController = new ServiceController();
        }

        public IList<Server> GetServers()
        {
            return _unitOfWork.ServerRepository.Get().ToList();
        }

        public IList<ApplicationService> GetApplicationServices()
        {
            var services = _unitOfWork.ApplicationServiceRepository.Get(includes: s => s.Server).ToList();

            services.ForEach(s => s.Status = GetServiceStatus(s.Server.ServerName, s.ServiceName));

            return services;
        }

        public IList<Application> GetApplications()
        {
            //ServiceController svcController = new ServiceController();

            return _unitOfWork.ApplicationRepository.Get(includes: a => a.Services.Select(s => s.Server)).ToList();
        }

        /// <summary>
        /// Returns the status of the service on the specified machine.
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>

        public string GetServiceStatus(string serverName, string serviceName)
        {
            try
            {
                _serviceController.MachineName = serverName;
                _serviceController.ServiceName = serviceName;

                return _serviceController.Status.ToString();
            }
            catch (InvalidOperationException ex)
            {
                return "Offline";
            }
        }

        /// <summary>
        /// Stops the service on specified machine.
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string StopService(string serverName, string serviceName)
        {
            ValidateStartStopServiceArgs(serverName, serviceName);

            try
            {
                _serviceController.MachineName = serverName;
                _serviceController.ServiceName = serviceName;

                _serviceController.Stop();
                _serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                
            }
            catch (Exception)
            {
                                
            }
            return _serviceController.Status.ToString();
        }

        /// <summary>
        /// Starts the service on the specified machine.
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="serviceName"></param>
        public string StartService(string serverName, string serviceName)
        {
            ValidateStartStopServiceArgs(serverName, serviceName);

            try
            {
                _serviceController.MachineName = serverName;
                _serviceController.ServiceName = serviceName;

                _serviceController.Start();
                _serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception)
            {
            }
            return _serviceController.Status.ToString();
        }

        /// <summary>
        /// Validates arguments have values.
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="serviceName"></param>
        private static void ValidateStartStopServiceArgs(string serverName, string serviceName)
        {
            if (string.IsNullOrEmpty(serverName))
                throw new ArgumentException("Server Name is null or empty");

            if (string.IsNullOrEmpty(serviceName))
                throw new ArgumentException("Service Name is null or empty");
        }
    }
}
