using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoproWA.Entities
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        public String ImgUrl { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Person> People { get; set; }

        public Movie()
        {
            Genres = new List<Genre>();
            People = new List<Person>();
        }
    }
}
