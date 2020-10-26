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
    public class UsersController : ApiController
    {
        private readonly IRepository repository;

        public UsersController(IRepository repository)
        {
            this.repository = repository;
        }
        
      
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<User> users = this.repository.GetAllUsers();
                if (users.Count() > 0)
                {
                    return Ok(users);
                }
                else
                {
                    return Ok("No Results Found");
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Sorry we are having a problem from our side");
            }
        }

       
        [HttpGet()]
        public IHttpActionResult Get(String id)
        {
            try
            {
                User user = this.repository.GetUser(id);
                if (user!=null)
                {
                    return Ok(user);
                }
                else
                {
                    return Ok("No results Found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Sorry we are having a problem from our side");
            }
        }
        [HttpPost]
        public IHttpActionResult AddUser([FromBody]User user)
        {
            try
            {
                this.repository.AddUser(user);
                return Ok("Succesfully added the user");
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.Conflict, "User with the username already exists");
            }
        }
        [HttpPut]
        public IHttpActionResult UpdatePassword([FromBody]User user)
        {
            try
            {
                this.repository.ChangePassword(user); 
                return Ok("Succesfully updated the user");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.Conflict, "User with this username and password does not exist");
            }
            
        }
        [HttpDelete]
        public IHttpActionResult Delete([FromBody]User user)
        {
            try
            {
                this.repository.DeleteUser(user);
                return Ok("Succesfully deleted the user");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.Conflict, "User with this username does not exist");
            }
        }
    }
}
