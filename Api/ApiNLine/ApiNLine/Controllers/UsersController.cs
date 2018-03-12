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
using ApiNLine.Models;

namespace ApiNLine.Controllers
{
    [Route("users")]
    public class UsersController : ApiController
    {
        private dbNLineEntities db = new dbNLineEntities();

        // GET: api/Users
        public IQueryable<user> Getuser()
        {
            return db.user;
        }

        // GET: api/Users/5
        [ResponseType(typeof(user))]
        public IHttpActionResult Getuser(string id)
        {
            user user = db.user.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuser(string id, user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.email)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(user))]
        public IHttpActionResult Postuser([FromBody]user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.user.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (userExists(user.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.email }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(user))]
        public IHttpActionResult Deleteuser(string id)
        {
            user user = db.user.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.user.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userExists(string id)
        {
            return db.user.Count(e => e.email == id) > 0;
        }
    }
}