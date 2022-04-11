using SoproWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MovieModel
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImgUrl { get; set; }
        public ICollection<GenreModel> GenreModels { get; set; }
        public ICollection<PersonModel> PersonModels { get; set; }


    }
}
