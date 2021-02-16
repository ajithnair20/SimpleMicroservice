using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Database;
using UserService.Database.Entities;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext db;
        public UserController() {
            db = new DatabaseContext();
        }

        //GET: api/User
        [HttpGet]
        public IEnumerable<User> Get() {
            return db.Users.ToList();
        }

        //GET: api/User/5
        [HttpGet("{id}", Name ="Get")]
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        //POST: api/User/5
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try 
            {
                db.Users.Add(user);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            } 
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                db.Users.Update(user);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
