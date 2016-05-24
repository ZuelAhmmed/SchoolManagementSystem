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
using StartupInstitute.Security;

namespace StartupInstitute.Controllers
{
    public class StudentAccountController : Controller
    {
        private InstituteDbContext db = new InstituteDbContext();
        private SecurityManager objSecurityManager = new SecurityManager();
        // GET: StudentAccount
        public ActionResult Index()
        {
            var studentAccounts = db.StudentAccounts.Include(s => s.ClassOrYears).Include(s => s.Gorups).Include(s => s.StudentConfirm);
            return View(studentAccounts.ToList());
        }

        // GET: StudentAccount/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAccount studentAccount = db.StudentAccounts.Find(id);
            if (studentAccount == null)
            {
                return HttpNotFound();
            }
            return View(studentAccount);
        }

        // GET: StudentAccount/Create
        public ActionResult Create()
        {
            ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears, "Code", "Name");
            ViewBag.GroupId = new SelectList(db.Groups, "GroupCode", "Name");
            ViewBag.StudentConfirmId = new SelectList(db.ConfirmationCatagories, "Code", "Name");
            return View();
        }

        // POST: StudentAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StudentAccount studentAccount)
        {
            //[Bind(Include = "AccountId,ClassOrYearId,ClassRollNo,GuardianNid,GroupId,Shift,Section,FamilyIncome,StudentConfirmId,ConfirmDate,ConfirmedBy,ExamPermissionId,PassingYear,UserName,Password,NidOrBirtgRegNo,EmailAddress,MobileNumber,FirstName,LasttName,OccupationId,FathersName,FathersOccupation,MothersName,MothersOccupation,DateOfBirth,PresentAddress,PermanentAddress,MaritarialStatus,Gender,Religion,BloodGroup,Nationality,RegDateTime,LastLoginDateTime")]
            if (ModelState.IsValid)
            {
                //db.StudentAccounts.Add(studentAccount);
               // db.SaveChanges();
                objSecurityManager.SignUp(studentAccount);
                return RedirectToAction("Index");
            }

            ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears, "Code", "Name", studentAccount.ClassOrYearId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupCode", "Name", studentAccount.GroupId);
            ViewBag.StudentConfirmId = new SelectList(db.ConfirmationCatagories, "Code", "Name", studentAccount.StudentConfirmId);
            return View(studentAccount);
        }

        // GET: StudentAccount/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAccount studentAccount = db.StudentAccounts.Find(id);
            if (studentAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears, "Code", "Name", studentAccount.ClassOrYearId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupCode", "Name", studentAccount.GroupId);
            ViewBag.StudentConfirmId = new SelectList(db.ConfirmationCatagories, "Code", "Name", studentAccount.StudentConfirmId);
            return View(studentAccount);
        }

        // POST: StudentAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,ClassOrYearId,ClassRollNo,GuardianNid,GroupId,Shift,Section,FamilyIncome,StudentConfirmId,ConfirmDate,ConfirmedBy,ExamPermissionId,PassingYear,UserName,Password,NidOrBirtgRegNo,EmailAddress,MobileNumber,FirstName,LasttName,OccupationId,FathersName,FathersOccupation,MothersName,MothersOccupation,DateOfBirth,PresentAddress,PermanentAddress,MaritarialStatus,Gender,Religion,BloodGroup,Nationality,RegDateTime,LastLoginDateTime")] StudentAccount studentAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears, "Code", "Name", studentAccount.ClassOrYearId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupCode", "Name", studentAccount.GroupId);
            ViewBag.StudentConfirmId = new SelectList(db.ConfirmationCatagories, "Code", "Name", studentAccount.StudentConfirmId);
            return View(studentAccount);
        }

        // GET: StudentAccount/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAccount studentAccount = db.StudentAccounts.Find(id);
            if (studentAccount == null)
            {
                return HttpNotFound();
            }
            return View(studentAccount);
        }

        // POST: StudentAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentAccount studentAccount = db.StudentAccounts.Find(id);
            db.StudentAccounts.Remove(studentAccount);
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
