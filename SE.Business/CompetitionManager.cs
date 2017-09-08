using System;
using System.Collections.Generic;
using SE.Business.Code;
using SE.DataTransfer;
using SE.Domain.Interfaces.Manager;
using SE.Domain.Interfaces.Repository;

namespace SE.Business
{
    public class CompetitionManager : ICompetitionManager
    {
        private readonly ICompetitionRepository _repository;

        public CompetitionManager(ICompetitionRepository competitionRepository)
        {
            _repository = competitionRepository;
        }

        public Guid Create(Competition competition)
        {
            competition.CompetitionID = Guid.NewGuid();
            _repository.Create(Mapping.Mapped.Map<Domain.Entities.Competition>(competition));
            return competition.CompetitionID;
        }

        public void Delete(Competition competition)
        {
            _repository.Delete(Mapping.Mapped.Map<Domain.Entities.Competition>(competition));
        }

        public Competition Get(Guid id)
        {
            return Mapping.Mapped.Map<Competition>(_repository.Get<Domain.Entities.Competition>(id));
        }

        public List<Competition> GetAll()
        {
            var competitionList = _repository.GetAll<Domain.Entities.Competition>();
            return Mapping.Mapped.Map<List<Competition>>(competitionList);
        }

        public void Update(Competition competition)
        {
            _repository.Update(Mapping.Mapped.Map<Domain.Entities.Competition>(competition));
        }
    }
}
