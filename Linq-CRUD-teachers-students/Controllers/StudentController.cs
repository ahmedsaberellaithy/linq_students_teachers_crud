using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linq_CRUD_teachers_students.Controllers
{
    public class StudentController : Controller
    {
        DataClasses1DataContext studentDC = new DataClasses1DataContext();
        // GET: Student
        public ActionResult Index()
        {
            var studentsDetails = from x in studentDC.Students select x;
            return Json(studentsDetails);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var getStudentDetails = studentDC.Students.Single(x => x.Id == id);
            return Json(getStudentDetails);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return Json(new object[] { new object() });
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student studentData)
        {
            try
            {
                // TODO: Add insert logic here
                studentDC.Students.InsertOnSubmit(studentData);
                studentDC.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Json(new object[] { new object() });
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var getStudentDetails = studentDC.Students.Single(x => x.Id == id);
            return Json(getStudentDetails);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student studentData)
        {
            try
            {
                // TODO: Add update logic here
                Student studentToBeUpdated = studentDC.Students.Single(x => x.Id == id);
                studentToBeUpdated.firstname = studentData.firstname;
                studentToBeUpdated.lastname = studentData.lastname;
                studentDC.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Json(new object[] { new object() });
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var getStudentDetails = studentDC.Students.Single(x => x.Id == id);
            return Json(getStudentDetails);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student collection)
        {
            try
            {
                // TODO: Add delete logic here
                var toBeDeletedStudent = studentDC.Students.Single(x => x.Id == id);
                studentDC.Students.DeleteOnSubmit(toBeDeletedStudent);
                studentDC.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Json(new object[] { new object() });
            }
        }
    }
}
