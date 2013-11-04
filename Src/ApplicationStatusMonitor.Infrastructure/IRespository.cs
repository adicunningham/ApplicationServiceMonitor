using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationStatusMonitor.Infrastructure
{

    public interface IRepository : IDisposable
    {
        int Add<T>(T entity);
        long Count<T>();
        long Count<T>(Expression<Func<T, bool>> expression);
        int Delete<T>(T entity);
        IList<T> GetAll<T>();
        IList<T> GetAll<T>(Expression<Func<T, bool>> expression);
        T GetSingle<T>(Expression<Func<T, bool>> expression);
        int Update<T>(T entity);
    }
}
