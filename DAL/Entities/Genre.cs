using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoproWA.Entities
{
    public class Genre
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public Genre()
        {
            Movies = new List<Movie>();
        }
    }
}
