using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinc.Domain.Entities;
using tinc.Domain.Interfaces.Repository;
using tinc.Repository.Context;

namespace tinc.Repository
{
    public class SportRepository : ISportRepository
    {
        private readonly RepositoryContext _context;

        public SportRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        //public SportRepository()
        //{
        //    _context = new RepositoryContext();
        //}
        public void Create<T>(T entity)
        {
            var entityToSave = entity as Sport;
            try
            {
                _context.Sport.Add(entityToSave);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
