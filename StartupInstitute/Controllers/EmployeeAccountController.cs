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
    public class EmployeeAccountController : Controller
    {
        private InstituteDbContext db = new InstituteDbContext();

        // GET: EmployeeAccount
        [Authorize(Roles = SecurityRoles.Admin)]
        public ActionResult Index()
        {
            var employeeAccounts = db.EmployeeAccounts.Include(e => e.Designation).Include(e => e.EmployeeCatagory).Include(e => e.Subject);
            return View(employeeAccounts.ToList());
        }

        // GET: EmployeeAccount/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAccount employeeAccount = db.EmployeeAccounts.Find(id);
            if (employeeAccount == null)
            {
                return HttpNotFound();
            }
            return View(employeeAccount);
        }

        // GET: EmployeeAccount/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationCode", "Name");
            ViewBag.EmployeeCatagoryId = new SelectList(db.SecurityRoles, "RoleId", "RoleName");
            ViewBag.SubjectCode = new SelectList(db.Subjects, "SubjectCode", "Name");
            return View();
        }

        // POST: EmployeeAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeAccount employeeAccount)
        {
            if (ModelState.IsValid)
            {
                SecurityManager manager = new SecurityManager();
                manager.SignUp(employeeAccount);
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationCode", "Name", employeeAccount.DesignationId);
            ViewBag.EmployeeCatagoryId = new SelectList(db.SecurityRoles, "RoleId", "RoleName", employeeAccount.EmployeeCatagoryId);
            ViewBag.SubjectCode = new SelectList(db.Subjects, "SubjectCode", "Name", employeeAccount.SubjectCode);
            return View(employeeAccount);
        }

        // GET: EmployeeAccount/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAccount employeeAccount = db.EmployeeAccounts.Find(id);
            if (employeeAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationCode", "Name", employeeAccount.DesignationId);
            ViewBag.EmployeeCatagoryId = new SelectList(db.SecurityRoles, "RoleId", "RoleName", employeeAccount.EmployeeCatagoryId);
            ViewBag.SubjectCode = new SelectList(db.Subjects, "SubjectCode", "Name", employeeAccount.SubjectCode);
            return View(employeeAccount);
        }

        // POST: EmployeeAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,EmployeeCatagoryId,DesignationId,SubjectCode,IndexNumber,ConfirmationId,ConfirmDate,ConfirmedBy,RetiredDate,UserName,Password,NidOrBirtgRegNo,EmailAddress,MobileNumber,FirstName,LasttName,OccupationId,FathersName,FathersOccupation,MothersName,MothersOccupation,DateOfBirth,PresentAddress,PermanentAddress,MaritarialStatus,Gender,Religion,BloodGroup,Nationality,RegDateTime,LastLoginDateTime")] EmployeeAccount employeeAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationCode", "Name", employeeAccount.DesignationId);
            ViewBag.EmployeeCatagoryId = new SelectList(db.SecurityRoles, "RoleId", "RoleName", employeeAccount.EmployeeCatagoryId);
            ViewBag.SubjectCode = new SelectList(db.Subjects, "SubjectCode", "Name", employeeAccount.SubjectCode);
            return View(employeeAccount);
        }

        // GET: EmployeeAccount/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAccount employeeAccount = db.EmployeeAccounts.Find(id);
            if (employeeAccount == null)
            {
                return HttpNotFound();
            }
            return View(employeeAccount);
        }

        // POST: EmployeeAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeeAccount employeeAccount = db.EmployeeAccounts.Find(id);
            db.EmployeeAccounts.Remove(employeeAccount);
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
