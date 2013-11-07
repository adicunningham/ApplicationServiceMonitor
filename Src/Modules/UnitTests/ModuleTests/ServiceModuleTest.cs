using System;
using System.Collections.Generic;
using ApplicationStatusMonitor.Data;
using ApplicationStatusMonitor.Infrastructure;
using ApplicationStatusMonitor.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceModule;

namespace ModuleTests
{
    [TestClass]
    public class ServiceModuleTest
    {
        private IApplicationServiceRepository _serviceRepository;
        private IStatusMonitorService _appMonitorService;
        private const string serverName = "ADRIANCUNNIAB0D";
        private const string serviceName = "IISADMIN";

        [TestInitialize]
        public void TestSetup()
        {
            _serviceRepository = new ApplicationServiceRepository();
            _appMonitorService = new ApplicationStatusMonitorService(_serviceRepository);
        }

        [TestMethod]
        public void TestGetServers()
        {
            IList<Server> servers = _appMonitorService.GetServers();
            Assert.IsTrue(servers.Count > 0); 
        }

        [TestMethod]
        public void TestGetApplications()
        {
            IList<Application> applications = _appMonitorService.GetApplications();
            Assert.IsTrue(applications.Count > 0);
        }

        [TestMethod]
        public void TestGetServiceStatus_IISAdminRunning()
        {
            string status = _appMonitorService.GetServiceStatus(serverName, serviceName);

            if(status != "Running")
                _appMonitorService.StartService(serverName, serviceName);

            status = _appMonitorService.GetServiceStatus(serverName, serviceName);
            Assert.AreEqual("Running", status);
            Console.WriteLine(@"IISAdmin Service Status: " + status);
        }

        [TestMethod]
        public void TestGetServiceStatus_ISSAdminStopped()
        {
            string status = _appMonitorService.GetServiceStatus(serverName, serviceName);
            Assert.AreEqual("Running", status);

            _appMonitorService.StopService(serverName, serviceName);

            status = _appMonitorService.GetServiceStatus(serverName, serviceName);
            Assert.AreEqual("Stopped", status);
            Console.WriteLine(@"IISAdmin Service Status: " + status);
        }

    }
}
