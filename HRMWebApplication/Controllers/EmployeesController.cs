using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMWebApplication;
using HRMWebApplication.Models;

namespace HRMWebApplication.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private HRMModel db = new HRMModel();

        // GET: Employees
        public ActionResult Index(string searchString)
        {
            var employees = db.Employees.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = db.Employees.Where(e => e.FullName.Contains(searchString) || e.ID.ToString().Contains(searchString) ).ToList();
            }
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Gender,FullName,BirthDate,BirthPlace,Address,PhoneNumber,PassportDetails")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Gender,FullName,BirthDate,BirthPlace,Address,PhoneNumber,PassportDetails,IsDeleted")] Employee employee)
        {
            Employee oldEmployee = db.Employees.AsNoTracking().FirstOrDefault(e => e.ID == employee.ID);
            User currentUser = db.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if (oldEmployee != null && employee != null && employee.IsDeleted != oldEmployee.IsDeleted && currentUser.UserRole != UserRole.Администратор)
            {
                ModelState.AddModelError("", "Изменять признак \"Удалено\" может только пользователь с ролью Адмиинистратор");
            }
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View("Delete", employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User currentUser = db.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if (currentUser.UserRole != UserRole.Администратор)
            {
                ModelState.AddModelError("", "Изменять признак \"Удалено\" может только пользователь с ролью Адмиинистратор");
            }
            Employee employee = db.Employees.Find(id);
            if (ModelState.IsValid)
            {                
                //db.Employees.Remove(employee);
                employee.IsDeleted = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);

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
