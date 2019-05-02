using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Exam_Practice.Models;

namespace Final_Exam_Practice.Controllers
{
    public class SchedulesController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Schedules
        public ActionResult Index(int year=2019)
        {
            var date = db.FootballSchedules.Where(x => x.Season == year);
            return View(date);
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballSchedule footballSchedule = db.FootballSchedules.Find(id);
            if (footballSchedule == null)
            {
                return HttpNotFound();
            }
            return View(footballSchedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Season,Opponent,Date,IsHomeGame")] FootballSchedule footballSchedule)
        {
            if (ModelState.IsValid)
            {
                db.FootballSchedules.Add(footballSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footballSchedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballSchedule footballSchedule = db.FootballSchedules.Find(id);
            if (footballSchedule == null)
            {
                return HttpNotFound();
            }
            return View(footballSchedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Season,Opponent,Date,IsHomeGame")] FootballSchedule footballSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footballSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footballSchedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballSchedule footballSchedule = db.FootballSchedules.Find(id);
            if (footballSchedule == null)
            {
                return HttpNotFound();
            }
            return View(footballSchedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FootballSchedule footballSchedule = db.FootballSchedules.Find(id);
            db.FootballSchedules.Remove(footballSchedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
