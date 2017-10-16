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
    public class ProfilesController : ApiController
    {
        private RegisterUserContext db = new RegisterUserContext();

        // GET: api/Profiles
        public IQueryable<Profile> GetProfiles()
        {
            return db.Profiles;
        }

        // GET: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetProfile(int id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfile(int id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.Id)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profiles
        [ResponseType(typeof(Profile))]
        public IHttpActionResult PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(profile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profile.Id }, profile);
        }




        //// POST: api/Profiles
        //[ResponseType(typeof(Profile))]
        //public IHttpActionResult PostProfile(Profile profile, HttpPostedFileBase image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (image != null && image.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(image.FileName);
        //            var guid = Guid.NewGuid().ToString();
        //            var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/img/"), guid + fileName);
        //            image.SaveAs(path);
        //            string fl = path.Substring(path.LastIndexOf("\\"));
        //            string[] split = fl.Split('\\');
        //            string newpath = split[1];
        //            string imagepath = "~/Content/img/" + newpath;

        //            profile.image = imagepath;
        //            db.Profiles.Add(profile);
        //            db.SaveChanges();
        //        }
        //        return Ok(1);
        //    }
        //    return CreatedAtRoute("DefaultApi", new { id = profile.Id }, profile);
        //}


        // DELETE: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult DeleteProfile(int id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(profile);
            db.SaveChanges();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileExists(int id)
        {
            return db.Profiles.Count(e => e.Id == id) > 0;
        }
    }
}