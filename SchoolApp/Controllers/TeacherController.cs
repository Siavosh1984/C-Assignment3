using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolApp.Models;

namespace SchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teacher/List
        public ActionResult List()
        {

            TeachersDataController controller = new TeachersDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeachersDataController controller = new TeachersDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {

            TeachersDataController controller = new TeachersDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);

        }

        //POST : /Teacher/Delete/{id}

        public ActionResult Delete(int id)
        {
            TeachersDataController controller = new TeachersDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //POST : /Author/Create
        [HttpPost]

        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, string HireDate, string Salary)
        {
            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;
            TeachersDataController controller = new TeachersDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

    }
}