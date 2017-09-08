using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.Domain.Interfaces.Manager
{
    public interface ICompetitionManager
    {
        Guid Create(DataTransfer.Competition sport);
        void Update(DataTransfer.Competition sport);
        void Delete(DataTransfer.Competition sport);
        DataTransfer.Competition Get(Guid id);
        List<DataTransfer.Competition> GetAll();
    }
}
