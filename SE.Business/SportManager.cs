using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE.DataTransfer;
using tinc.Business.Code;
using tinc.Domain.Interfaces.Manager;
using tinc.Domain.Interfaces.Repository;

namespace tinc.Business
{
    public class SportManager : ISportManager
    {
        private readonly ISportRepository _repository;

        public SportManager(ISportRepository sportRepository)
        {
            _repository = sportRepository;
        }

        public Guid Create(Sport sport)
        {
            sport.ID = Guid.NewGuid();
            _repository.Create(Mapping.Mapped.Map<Domain.Entities.Sport>(sport));
            return sport.ID;
        }

        public void Delete(Sport sport)
        {
            if(sport.ID != null)
            {
                _repository.Delete(Mapping.Mapped.Map<Domain.Entities.Sport>(sport));
            }
        }

        public Sport Get(Guid id)
        {
            if (id != null)
            {
                return Mapping.Mapped.Map<Sport>(_repository.Get<Domain.Entities.Sport>(id));
            }
            return null;
        }

        public List<Sport> GetAll()
        {
            var sportList = _repository.GetAll<Domain.Entities.Sport>();

            return Mapping.Mapped.Map<List<Sport>>(sportList);
        }

        public void Update(Sport sport)
        {
            if (sport.ID != null)
            {
                _repository.Update(Mapping.Mapped.Map<Domain.Entities.Sport>(sport));
            }
        }
    }
}
