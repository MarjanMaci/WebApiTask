using Microsoft.EntityFrameworkCore;
using SoproWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MovieDAL
    {
        private ApplicationDBContext applicationDB;

        public MovieDAL(ApplicationDBContext applicationDBContext)
        {
            applicationDB = applicationDBContext;
        }
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies= applicationDB.Movies.Include(x => x.Genres).Include(x => x.People).ToList();
            return movies;
        }

        public Movie GetMovie(int id)
        {
            Movie movie = applicationDB.Movies.FirstOrDefault(x => x.id == id);
            return movie;
        }

        public void PostMovie(Movie movie)
        {
            Movie newMovie = new Movie();
            newMovie.Name = movie.Name;
            newMovie.Description = movie.Description;
            newMovie.ImgUrl = movie.ImgUrl;
            applicationDB.Set<Movie>().Add(newMovie);
            applicationDB.SaveChanges();
            foreach(var genre in movie.Genres)
            {
                Genre genreToAdd = applicationDB.Genres.FirstOrDefault(x => x.id == genre.id);
                applicationDB.Movies.FirstOrDefault(x => x.Name == movie.Name).Genres.Add(genreToAdd);
            }
            applicationDB.SaveChanges();
            foreach (var person in movie.People)
            {
                Person personToAdd = applicationDB.Persons.FirstOrDefault(x => x.id == person.id);
                applicationDB.Movies.FirstOrDefault(x => x.Name == movie.Name).People.Add(personToAdd);
            }
            applicationDB.SaveChanges();
        }
        public void EditMovie(Movie movie)
        {
            Movie newMovie = new Movie();
            newMovie = applicationDB.Movies.FirstOrDefault(x => x.id == movie.id);
            applicationDB.Movies.Remove(newMovie);
            newMovie.Name = movie.Name;
            newMovie.Description = movie.Description;
            newMovie.ImgUrl = movie.ImgUrl;
            applicationDB.Movies.Add(newMovie);
            applicationDB.SaveChanges();
            foreach (var genre in movie.Genres)
            {
                Genre genreToAdd = applicationDB.Genres.FirstOrDefault(x => x.id == genre.id);
                applicationDB.Movies.FirstOrDefault(x => x.Name == newMovie.Name).Genres.Add(genreToAdd);
            }
            applicationDB.SaveChanges();
            foreach (var person in movie.People)
            {
                Person personToAdd = applicationDB.Persons.FirstOrDefault(x => x.id == person.id);
                applicationDB.Movies.FirstOrDefault(x => x.Name == newMovie.Name).People.Add(personToAdd);
            }
            applicationDB.SaveChanges();
        }
    }
}
