using SoproWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class GenreDAL
    {
        private ApplicationDBContext applicationDB;

        public GenreDAL(ApplicationDBContext applicationDBContext)
        {
            applicationDB = applicationDBContext;
        }
        public List<Genre> GetAllGenres()
        {
            return applicationDB.Set<Genre>().ToList();
        }
    }
}
