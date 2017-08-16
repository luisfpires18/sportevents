using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace tinc.Repository
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class TemporaryDbContextFactory : IDbContextFactory<Context.RepositoryContext>
    {
        public Context.RepositoryContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<Context.RepositoryContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=tinc;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new Context.RepositoryContext(builder.Options);
        }

        Context.RepositoryContext IDbContextFactory<Context.RepositoryContext>.Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<Context.RepositoryContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=tinc;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new Context.RepositoryContext(builder.Options);
        }
    }
}
