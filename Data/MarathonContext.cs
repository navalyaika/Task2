using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Data
{
    public class MarathonContext: DbContext
    {
        public DbSet<MarathonMember> MarathonMember { get; set; }
        public MarathonContext(DbContextOptions<MarathonContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MarathonMember>().HasData(new MarathonMember 
            { Id = 1, Name = "Иван", Gender = 'М', Age = 10, Experience = 10, CityOfResidence = "Томск" });
        }

    }
}
