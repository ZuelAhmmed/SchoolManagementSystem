using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StartupInstitute.Models;
using StartupInstitute.Models.DbModels;
using StartupInstitute.ViewModels;

namespace StartupInstitute.Controllers
{
    public class StudentAttendenceController : Controller
    {
        private InstituteDbContext db = new InstituteDbContext();

        // GET: StudentAttendence
        public ActionResult Index()
        {
            var studentAttendences = db.StudentAttendences.Include(s => s.ClassOrYears);
            return View(studentAttendences.ToList());
        }

        // GET: StudentAttendence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendences.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendence);
        }

        // GET: StudentAttendence/Create
        public ActionResult Create()
        {
            ViewStudentAttendence objStudentAttendence = new ViewStudentAttendence();
            objStudentAttendence.Class = new SelectList(db.ClassOrYears.OrderBy(s => s.Name), "Code", "Name");
           // ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears.OrderBy(s => s.Name), "Code", "Name");
            return View(objStudentAttendence);
        }

        // POST: StudentAttendence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentAttendence")] ViewStudentAttendence objStudentAttendence)
        {
         //   Id,ClassOrYearId,TotalStudent,FemaleStudentNo,TotalPresentStudent,PresentFemaleStudent,DateTime
            if (ModelState.IsValid)
            {
                db.StudentAttendences.Add(objStudentAttendence.StudentAttendence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            objStudentAttendence.Class = new SelectList(db.ClassOrYears.OrderBy(s => s.Name), "Code", "Name", objStudentAttendence.Class);

          //  ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears.OrderBy(s => s.Name), "Code", "Name", studentAttendence.ClassOrYearId);
            return View(objStudentAttendence);
        }

        // GET: StudentAttendence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendences.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears, "Code", "Name", studentAttendence.ClassOrYearId);
            return View(studentAttendence);
        }

        // POST: StudentAttendence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassOrYearId,TotalStudent,FemaleStudentNo,TotalPresentStudent,PresentFemaleStudent,DateTime")] StudentAttendence studentAttendence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears, "Code", "Name", studentAttendence.ClassOrYearId);
            return View(studentAttendence);
        }

        // GET: StudentAttendence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendences.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendence);
        }

        // POST: StudentAttendence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAttendence studentAttendence = db.StudentAttendences.Find(id);
            db.StudentAttendences.Remove(studentAttendence);
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
