using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoproWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoproWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationDBContext applicationDB;
        public MovieController(ApplicationDBContext applicationDBContext)
        {
            this.applicationDB = applicationDBContext;
        }

        //Sending all data (movie,genres,people)
        [HttpGet]
        public List<MovieModel> GetAllMovies()
        {
            BLL.MovieBLL movieBLL= new BLL.MovieBLL(applicationDB);
            return movieBLL.GetAllMovies();
        }
        [HttpGet]
        [Route("geteverything")]
        public ActionResult<GMPModel> GetAllData()
        {
            BLL.GMPBLL _GMPBLL = new BLL.GMPBLL(applicationDB);
            return Ok(_GMPBLL.GetAllData());
        }
        [HttpGet]
        [Route("get")]
        public ActionResult<MovieModel> GetMovie(int id)
        {
            BLL.MovieBLL movieBLL = new BLL.MovieBLL(applicationDB);
            return Ok(movieBLL.GetMovie(id));
        }
        [HttpPost]
        [Route("add")]
        public void AddMovie([FromBody] MovieModel movieModel)
        {
            BLL.MovieBLL movieBLL = new BLL.MovieBLL(applicationDB);
            movieBLL.AddMovie(movieModel);
        }
    }

}

