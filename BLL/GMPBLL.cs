using AutoMapper;
using BLL.Models;
using SoproWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GMPBLL
    {
        private ApplicationDBContext applicationDB;
        private Mapper mapper;

        public GMPBLL(ApplicationDBContext applicationDBContext)
        {
            applicationDB = applicationDBContext;
            var configMapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Genre, GenreModel>().ReverseMap();
                cfg.CreateMap<Person, PersonModel>().ReverseMap();
                cfg.CreateMap<Movie, MovieModel>().ForMember(x => x.GenreModels, c => c.MapFrom(s => s.Genres))
                                                  .ForMember(x => x.PersonModels, c => c.MapFrom(s => s.People));
            });
            mapper = new Mapper(configMapper);
        }

        public GMPModel GetAllData()
        {
            DAL.MovieDAL movieDAL = new DAL.MovieDAL(applicationDB);
            DAL.GenreDAL genreDAL = new DAL.GenreDAL(applicationDB);
            DAL.PersonDAL personDAL = new DAL.PersonDAL(applicationDB);


            List<Movie> movies = movieDAL.GetAllMovies();
            List<MovieModel> moviesDTO = mapper.Map<List<Movie>, List<MovieModel>>(movies);

            List<Genre> genres = genreDAL.GetAllGenres();
            List<GenreModel> genresDTO = mapper.Map<List<Genre>, List<GenreModel>>(genres);

            List<Person> people = personDAL.GetAllPeople();
            List<PersonModel> personDTO = mapper.Map<List<Person>, List<PersonModel>>(people);

            GMPModel allDataDTO = new GMPModel();
            allDataDTO.MovieModels = moviesDTO;
            allDataDTO.GenreModels = genresDTO;
            allDataDTO.PersonModels = personDTO;
            return allDataDTO;
        }
    }
}
