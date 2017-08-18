using System;
using System.Collections.Generic;
using SE.Business.Code;
using SE.DataTransfer;
using SE.Domain.Interfaces.Manager;
using SE.Domain.Interfaces.Repository;

namespace SE.Business
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
            sport.SportID = Guid.NewGuid();
            _repository.Create(Mapping.Mapped.Map<Domain.Entities.Sport>(sport));
            return sport.SportID;
        }

        public void Delete(Sport sport)
        {
            if(sport.SportID != null)
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
            if (sport.SportID != null)
            {
                _repository.Update(Mapping.Mapped.Map<Domain.Entities.Sport>(sport));
            }
        }
    }
}
