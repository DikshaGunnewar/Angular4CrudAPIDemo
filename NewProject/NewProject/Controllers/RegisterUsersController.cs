using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NewProject.Models;
using System.Web.Http.Cors;

namespace NewProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class RegisterUsersController : ApiController
    {
        private RegisterUserContext db = new RegisterUserContext();

        // GET: api/RegisterUsers
        public IQueryable<RegisterUser> GetRegisterUsers()
        {
            return db.RegisterUsers;
        }

        // GET: api/RegisterUsers/5
        [ResponseType(typeof(RegisterUser))]
        public IHttpActionResult GetRegisterUser(int id)
        {
            RegisterUser registerUser = db.RegisterUsers.Find(id);
            if (registerUser == null)
            {
                return NotFound();
            }

            return Ok(registerUser);
        }

        // PUT: api/RegisterUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegisterUser(int id,RegisterUser registerUser)
        {

            //var res = db.RegisterUsers.Find(registerUser.Id);

            //res.name = registerUser.name;
            //res.email = registerUser.email;
            //res.password = registerUser.password;
            //db.SaveChanges();
            //return Ok("ok");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registerUser.Id)
            {
                return BadRequest();
            }

            db.Entry(registerUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RegisterUsers
        [ResponseType(typeof(RegisterUser))]
        public IHttpActionResult PostRegisterUser(RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegisterUsers.Add(registerUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registerUser.Id }, registerUser);
        }

        // DELETE: api/RegisterUsers/5
        [ResponseType(typeof(RegisterUser))]
        public IHttpActionResult DeleteRegisterUser(int id)
        {
            RegisterUser registerUser = db.RegisterUsers.Find(id);
            if (registerUser == null)
            {
                return NotFound();
            }

            db.RegisterUsers.Remove(registerUser);
            db.SaveChanges();

            return Ok(registerUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisterUserExists(int id)
        {
            return db.RegisterUsers.Count(e => e.Id == id) > 0;
        }
    }
}