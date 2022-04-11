using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoproWA.Entities
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public PersonRole PersonRole { get; set; }
        public Person()
        {
            Movies = new List<Movie>();
        }
    }
}
