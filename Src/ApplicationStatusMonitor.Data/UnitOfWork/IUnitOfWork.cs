using System;
using ApplicationStatusMonitor.Data.Repository;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        Repository<Application> ApplicationRepository { get; }
        Repository<ApplicationService> ApplicationServiceRepository { get; }
        Repository<Model.Entities.Environment> EnvironmentRepository { get; }
        Repository<Server> ServerRepository { get; }
        Repository<ServiceType> ServiceTypeRepository { get; }
        Repository<Status> StatusRepository { get; }

        void Save();
    }
}
