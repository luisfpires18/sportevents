using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.Domain.Interfaces.Manager
{
    public interface IEventManager
    {
        Guid Create(DataTransfer.Event sport);
        void Update(DataTransfer.Event sport);
        void Delete(DataTransfer.Event sport);
        DataTransfer.Event Get(Guid id);
        List<DataTransfer.Event> GetAll();
    }
}
