﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE.Domain.Entities;

namespace SE.Repository.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
          : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Extra> Extra { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<Team> Team { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            // BUILDER - Sport
            builder.Entity<Sport>().HasKey(s => s.SportID);
            builder.Entity<Sport>().HasIndex(s => s.Name);
          


            base.OnModelCreating(builder);
        }
    }
}
