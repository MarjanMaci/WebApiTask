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
    public class MovieBLL
    {
        private ApplicationDBContext applicationDB;
        private Mapper mapper;

        public MovieBLL(ApplicationDBContext applicationDBContext)
        {
            applicationDB = applicationDBContext;
            var configMapper = new MapperConfiguration(cfg => { cfg.CreateMap<Genre, GenreModel>().ReverseMap();
                cfg.CreateMap<Person, PersonModel>().ReverseMap();
                cfg.CreateMap<Movie, MovieModel>().ForMember(x => x.GenreModels, c => c.MapFrom(s => s.Genres))
                                                  .ForMember(x=>x.PersonModels, c=>c.MapFrom(s=>s.People))
                                                  .ReverseMap();
            });
            mapper = new Mapper(configMapper);
        }

        public List<MovieModel> GetAllMovies()
        {
            DAL.MovieDAL movieDAL = new DAL.MovieDAL(applicationDB);
            
            List<Movie> movies = movieDAL.GetAllMovies();
            List<MovieModel> moviesDTO = mapper.Map<List<Movie>, List<MovieModel>>(movies);

            return moviesDTO;
        }

        public MovieModel GetMovie(int id)
        {
            DAL.MovieDAL movieDAL = new DAL.MovieDAL(applicationDB);
            Movie movie = movieDAL.GetMovie(id);
            MovieModel movieDTO = mapper.Map<Movie, MovieModel>(movie);
            return movieDTO;
        }

        public void AddMovie(MovieModel movieModel)
        {
            DAL.MovieDAL movieDAL = new DAL.MovieDAL(applicationDB);
            Movie movie = mapper.Map<MovieModel, Movie>(movieModel);
            movieDAL.PostMovie(movie);
        }
    }
}
