using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.Domain.Interfaces.Manager
{
    public interface ISportManager
    {
        Guid Create(SE.DataTransfer.Sport sport);
        void Update(SE.DataTransfer.Sport sport);
        void Delete(SE.DataTransfer.Sport sport);
        SE.DataTransfer.Sport Get(Guid id);
        List<SE.DataTransfer.Sport> GetAll();
    }
}
