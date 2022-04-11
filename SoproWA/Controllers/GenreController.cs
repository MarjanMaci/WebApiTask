using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoproWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoproWA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private ApplicationDBContext applicationDB;
        public GenreController(ApplicationDBContext applicationDBContext)
        {
            this.applicationDB = applicationDBContext;
        }
        [HttpGet]
        public ActionResult<List<GenreModel>> GetGenres()
        {
            BLL.GenreBLL genreBLL = new BLL.GenreBLL(applicationDB);
            return Ok(genreBLL.GetGenress());
        }
    }
}
