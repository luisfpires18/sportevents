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
    public class SportRepository : ISportRepository
    {
        private readonly RepositoryContext _context;

        public SportRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Create<T>(T entity)
        {
            var entityToSave = entity as Sport;
            try
            {
                _context.Sport.Add(entityToSave);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
        }

        public void Delete<T>(T entity)
        {
            var entityToDelete = entity as Sport;
            try
            {
                var entityInDb = _context.Sport.Single(s => s.SportID == entityToDelete.SportID);
                _context.Sport.Remove(entityInDb);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }

        }

        public T Get<T>(Guid id)
        {
            object obj = _context.Sport.AsNoTracking().Single(s => s.SportID == id);
            if (obj is T)
                return (T) obj;

            return default(T);
        }

        public List<T> GetAll<T>()
        {
            try
            {
                return _context.Sport.AsNoTracking().ToList() as List<T>;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Update<T>(T entity)
        {
            var entityToEdit = entity as Sport;
            try
            {
                var entityInDb = _context.Sport.Single(s => s.SportID == entityToEdit.SportID);
                entityInDb.Name = entityToEdit.Name;
                entityInDb.Responsible = entityToEdit.Responsible;

                _context.Sport.Update(entityInDb);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }

        }
    }
}
