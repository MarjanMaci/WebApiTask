using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoproWA.Entities
{
        public class ApplicationDBContext : DbContext
        {
            public ApplicationDBContext(){}

            public ApplicationDBContext(DbContextOptions options) : base(options) { }
            public DbSet<Genre> Genres { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                EnumToNumberConverter<PersonRole, int>
                    converter = new EnumToNumberConverter<PersonRole, int>();

                modelBuilder.Entity<Person>()
                            .Property(e => e.PersonRole)
                            .HasConversion(converter);
            }
    }
}
