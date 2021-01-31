using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linq_CRUD_teachers_students.Controllers
{
    public class TeacherController : Controller
    {
        DataClasses1DataContext teacherDC = new DataClasses1DataContext();
        // GET: Teacher
        public ActionResult Index()
        {
            var teachersDetails = from x in teacherDC.Teachers select x;
            return Json(teachersDetails);
        }

        // GET: teacher/Details/5
        public ActionResult Details(int id)
        {
            var getTeacherDetails = teacherDC.Teachers.Single(x => x.Id == id);
            return Json(getTeacherDetails);
        }

        // GET: teacher/Create
        public ActionResult Create()
        {
            return Json(new object[] { new object() });
        }

        // POST: teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher teacherData)
        {
            try
            {
                // TODO: Add insert logic here
                teacherDC.Teachers.InsertOnSubmit(teacherData);
                teacherDC.SubmitChanges();
                return Json(teacherData);
            }
            catch
            {
                return Json(new object[] { new object() });
            }
        }

        // GET: teacher/Edit/5
        public ActionResult Edit(int id)
        {
            var getTeacherDetails = teacherDC.Teachers.Single(x => x.Id == id);
            return Json(getTeacherDetails);
        }

        // POST: teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Teacher teacherData)
        {
            try
            {
                // TODO: Add update logic here
                Teacher teacherToBeUpdated = teacherDC.Teachers.Single(x => x.Id == id);
                teacherToBeUpdated.firstname = teacherData.firstname;
                teacherToBeUpdated.lastname = teacherData.lastname;
                teacherDC.SubmitChanges();
                return Json(teacherToBeUpdated);
            }
            catch
            {
                return Json(new object[] { new object() });
            }
        }

        // GET: teacher/Delete/5
        public ActionResult Delete(int id)
        {
            var getTeacherDetails = teacherDC.Teachers.Single(x => x.Id == id);
            return Json(getTeacherDetails);
        }

        // POST: teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Teacher collection)
        {
            try
            {
                // TODO: Add delete logic here
                var toBeDeletedteacher = teacherDC.Teachers.Single(x => x.Id == id);
                teacherDC.Teachers.DeleteOnSubmit(toBeDeletedteacher);
                teacherDC.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Json(new object[] { new object() });
            }
        }
    }
}
