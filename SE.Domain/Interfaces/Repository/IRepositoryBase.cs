using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinc.Domain.Interfaces.Repository
{
    public interface IRepositoryBase
    {
        void Create<T>(T entity);
        void Update<T>(T entity);
        void Delete<T>(T entity);
        T Get<T>(Guid id);
        List<T> GetAll<T>();
    }
}
