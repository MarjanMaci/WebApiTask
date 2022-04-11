using SoproWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PersonModel
    {
        public int id { get; set; }
        public String Name { get; set; }
        public PersonRole PersonRole { get; set; }
    }
}
