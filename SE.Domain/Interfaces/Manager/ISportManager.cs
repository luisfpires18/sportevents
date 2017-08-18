using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.Domain.Interfaces.Manager
{
    public interface ISportManager
    {
        Guid Create(DataTransfer.Sport sport);
        void Update(DataTransfer.Sport sport);
        void Delete(DataTransfer.Sport sport);
        DataTransfer.Sport Get(Guid id);
        List<DataTransfer.Sport> GetAll();
    }
}
