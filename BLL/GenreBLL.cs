using SoproWA.Entities;
using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Models;

namespace BLL
{
    public class GenreBLL
    {
        private ApplicationDBContext applicationDB;
        private Mapper mapper;

        public GenreBLL (ApplicationDBContext applicationDBContext)
        {
            applicationDB = applicationDBContext;
            var configMapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreModel>().ReverseMap());
            mapper = new Mapper(configMapper);
        }
        public List<GenreModel> GetGenress()
        {
            DAL.GenreDAL genreDAL = new DAL.GenreDAL(applicationDB);
            List<Genre> genres = genreDAL.GetAllGenres();
            List<GenreModel> genresDTO = mapper.Map<List<Genre>, List<GenreModel>>(genres);
            return genresDTO;
        }
    }
}
