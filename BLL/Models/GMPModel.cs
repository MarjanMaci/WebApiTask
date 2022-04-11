using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class GMPModel
    {
        public ICollection<GenreModel> GenreModels { get; set; }
        public ICollection<MovieModel> MovieModels { get; set; }
        public ICollection<PersonModel> PersonModels { get; set; }

    }
}
