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
    public class AuthenticationController : ApiController
    {
        private readonly IRepository repository;
        public AuthenticationController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IHttpActionResult Register([FromBody]User user)
        {
            try
            {
                this.repository.AddUser(user);
                return Ok("Succesfully added the user");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.Conflict, "User with the username already exists");
            }
        }

      
        public IHttpActionResult Login([FromBody]User user)
        {
            try
            {
                String key=this.repository.Login(user);
                    return Ok(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.BadRequest, "Something has gone wrong");
            }
        }
    }
}
