using Microsoft.EntityFrameworkCore;
using Rehber.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.DataAccess
{
    public class PersonDbContext:DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<InfoType> InfoTypes { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
    }
}
