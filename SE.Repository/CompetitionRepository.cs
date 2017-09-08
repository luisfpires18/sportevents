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
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly RepositoryContext _context;

        public CompetitionRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Create<T>(T entity)
        {
            var entityToSave = entity as Competition;
            try
            {
                if (entityToSave != null)
                    _context.Competition.Add(entityToSave);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
        }

        public void Delete<T>(T entity)
        {
            var entityToDelete = entity as Competition;
            try
            {
                var entityInDb = _context.Competition.Single(s => s.CompetitionID == entityToDelete.CompetitionID);
                _context.Competition.Remove(entityInDb);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }

        }

        public T Get<T>(Guid id)
        {
            object obj = _context.Competition.AsNoTracking().Single(s => s.CompetitionID == id);
            if (obj is T)
                return (T) obj;

            return default(T);
        }

        public List<T> GetAll<T>()
        {
            return _context.Competition
                .AsNoTracking()
              //  .Include(c => c.Event)
                .ToList() as List<T>;
        }

        public void Update<T>(T entity)
        {
            var entityToEdit = entity as Competition;
            try
            {
                var entityInDb = _context.Competition.Single(s => s.CompetitionID == entityToEdit.CompetitionID);
                if (entityToEdit != null)
                {
                    entityInDb.Name = entityToEdit.Name;
                    entityInDb.Distance = entityToEdit.Distance;
                }

                _context.Competition.Update(entityInDb);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }

        }
    }
}
