using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DinnersOut.Models;

namespace DinnersOut.Controllers
{
    public class CourseClassesController : Controller
    {
        private RepoSeedModel db = new RepoSeedModel();

        // GET: CourseClasses
        public ActionResult Index()
        {
            var classCourses = db.ClassCourses.Include(c => c.Class).Include(c => c.Course);
            return View(classCourses.ToList());
        }

        // GET: CourseClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourses.Find(id);
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            return View(classCourse);
        }

        // GET: CourseClasses/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name");
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: CourseClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,CourseId,LocationId,StartDate,EndDate")] ClassCourse classCourse)
        {
            if (ModelState.IsValid)
            {
                db.ClassCourses.Add(classCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", classCourse.ClassId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", classCourse.CourseId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View(classCourse);
        }

        // GET: CourseClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourses.Find(id);
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", classCourse.ClassId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", classCourse.CourseId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View(classCourse);
        }

        // POST: CourseClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,CourseId,LocationId,StartDate,EndDate")] ClassCourse classCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", classCourse.ClassId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", classCourse.CourseId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View(classCourse);
        }

        // GET: CourseClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCourse classCourse = db.ClassCourses.Find(id);
            if (classCourse == null)
            {
                return HttpNotFound();
            }
            return View(classCourse);
        }

        // POST: CourseClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassCourse classCourse = db.ClassCourses.Find(id);
            db.ClassCourses.Remove(classCourse);
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
