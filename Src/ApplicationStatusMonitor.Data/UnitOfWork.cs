using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationServiceDb _context = new ApplicationServiceDb();
        private Repository<Application> _applicationRepository;
        private Repository<ApplicationService> _appServiceRepository;
        private Repository<Model.Entities.Environment> _environmentRepository;
        private Repository<Server> _serverRepository;
        private Repository<ServiceType> _serviceTypeRepository;
        private Repository<Status> _statusRepository;

        public Repository<Application> ApplicationRepository
        {
            get { return _applicationRepository ?? (_applicationRepository = new Repository<Application>(_context)); }
        }

        public Repository<ApplicationService> ApplicationServiceRepository
        {
            get { return _appServiceRepository ?? (_appServiceRepository = new Repository<ApplicationService>(_context)); }
        }

        public Repository<Model.Entities.Environment> EnvironmentRepository
        {
            get { return _environmentRepository ?? (_environmentRepository = new Repository<Model.Entities.Environment>(_context)); }
        }

        public Repository<Server> ServerRepository
        {
            get { return _serverRepository ?? (_serverRepository = new Repository<Server>(_context)); }
        }

        public Repository<ServiceType> ServiceTypeRepository
        {
            get { return _serviceTypeRepository ?? (_serviceTypeRepository = new Repository<ServiceType>(_context)); }
        }

        public Repository<Status> StatusRepository
        {
            get { return _statusRepository ?? (_statusRepository = new Repository<Status>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
