using apifreader.DataAccessLayer;
using apifreader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apifreader.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IRepository repository;

        public MoviesController(IRepository repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult GetMovies()
        {
            try
            {
                IEnumerable<Movie> movies = this.repository.getAllMovies();
                if (movies.Count() > 0)
                {
                    return Ok(movies);
                }
                else
                {
                    return Ok("No Results Found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Sorry we are having a problem from our side");
            }
        }

    }
}
