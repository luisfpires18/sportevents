using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE.Domain.Entities;
using SE.Domain.Interfaces.Repository;
using SE.Repository.Context;

namespace SE.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly RepositoryContext _context;

        public EventRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Create<T>(T entity)
        {
            var entityToSave = entity as Event;
            try
            {
                if (entityToSave != null)
                    _context.Event.Add(entityToSave);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
        }

        public void Delete<T>(T entity)
        {
            var entityToDelete = entity as Event;
            try
            {
                var entityInDb = _context.Event.Single(s => s.EventID == entityToDelete.EventID);
                _context.Event.Remove(entityInDb);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }

        }

        public T Get<T>(Guid id)
        {
            object obj = _context.Event.AsNoTracking().Single(s => s.EventID == id);
            if (obj is T)
                return (T) obj;

            return default(T);
        }

        public List<T> GetAll<T>()
        {
            try
            {
                return _context.Event.AsNoTracking()
                 //   .Include(e => e.Sport)
                 //   .Include(e => e.Competitions)
                    .OrderBy(e => e.Name).ToList() as List<T>;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Update<T>(T entity)
        {
            var entityToEdit = entity as Event;
            try
            {
                var entityInDb = _context.Event.Single(s => s.EventID == entityToEdit.EventID);
                if (entityToEdit != null)
                {
                    entityInDb.Name = entityToEdit.Name;
                    entityInDb.Local = entityToEdit.Local;
                    entityInDb.EventDate = entityToEdit.EventDate;
                }

                _context.Event.Update(entityInDb);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }

        }
    }
}
