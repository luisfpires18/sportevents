using System;
using System.Collections.Generic;
using SE.Business.Code;
using SE.DataTransfer;
using SE.Domain.Interfaces.Manager;
using SE.Domain.Interfaces.Repository;

namespace SE.Business
{
    public class EventManager : IEventManager
    {
        private readonly IEventRepository _repository;

        public EventManager(IEventRepository eRepository)
        {
            _repository = eRepository;
        }

        public Guid Create(Event e)
        {
            e.EventID = Guid.NewGuid();
            _repository.Create(Mapping.Mapped.Map<Domain.Entities.Event>(e));
            return e.EventID;
        }

        public void Delete(Event e)
        {
          _repository.Delete(Mapping.Mapped.Map<Domain.Entities.Event>(e));
        }

        public Event Get(Guid id)
        {
            return Mapping.Mapped.Map<Event>(_repository.Get<Domain.Entities.Event>(id));
        }

        public List<Event> GetAll()
        {
            var eList = _repository.GetAll<Domain.Entities.Event>();

            return Mapping.Mapped.Map<List<Event>>(eList);
        }

        public void Update(Event e)
        {
          _repository.Update(Mapping.Mapped.Map<Domain.Entities.Event>(e));
        }
    }
}
