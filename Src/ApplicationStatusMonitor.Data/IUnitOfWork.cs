using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data
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
