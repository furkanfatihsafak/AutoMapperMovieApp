using MovieApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entity
{
    public class ApplicationEfContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovieEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
