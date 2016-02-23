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
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class TaskXesController : ApiController
    {
        private TheDatabase db = new TheDatabase();

        // GET: api/TaskXes
        public IQueryable<TaskX> GetTasks()
        {
            return db.Tasks;
        }

        // GET: api/TaskXes/5
        [ResponseType(typeof(TaskX))]
        public IHttpActionResult GetTaskX(int id)
        {
            TaskX taskX = db.Tasks.Find(id);
            if (taskX == null)
            {
                return NotFound();
            }

            return Ok(taskX);
        }

        // PUT: api/TaskXes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskX(int id, TaskX taskX)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskX.TaskXID)
            {
                return BadRequest();
            }

            db.Entry(taskX).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskXExists(id))
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

        // POST: api/TaskXes
        [ResponseType(typeof(TaskX))]
        public IHttpActionResult PostTaskX(TaskX taskX)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(taskX);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taskX.TaskXID }, taskX);
        }

        // DELETE: api/TaskXes/5
        [ResponseType(typeof(TaskX))]
        public IHttpActionResult DeleteTaskX(int id)
        {
            TaskX taskX = db.Tasks.Find(id);
            if (taskX == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(taskX);
            db.SaveChanges();

            return Ok(taskX);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskXExists(int id)
        {
            return db.Tasks.Count(e => e.TaskXID == id) > 0;
        }
    }
}