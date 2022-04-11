using SoproWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonDAL
    {
        private ApplicationDBContext applicationDB;

        public PersonDAL(ApplicationDBContext applicationDBContext)
        {
            applicationDB = applicationDBContext;
        }
        public List<Person> GetAllPeople()
        {
            List<Person> people = applicationDB.Set<Person>().ToList();
            return people;
        }
    }
}
