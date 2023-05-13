using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entity.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
    }

    public class MovieEntityConfiguration : EntityTypeConfiguration<MovieEntity>
    {
        public MovieEntityConfiguration()
        {
            Property(c => c.Name).IsRequired();
            ToTable("Movie");
        }
    }
}
