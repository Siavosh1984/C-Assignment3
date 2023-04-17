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
            Teacher SelectedTeacher = controller.FindTeacher(id);


            return View(SelectedTeacher);
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


        /// <summary>
        /// Routes to a dynamically generated "Teacher Update" Page. Gathers information from the database.
        /// </summary>
        /// <param name="id">Id of the Teacher</param>
        /// <returns>A dynamic "Update Teacher" webpage which provides the current information of the Teacher and asks the user for new information as part of a form.</returns>
        /// <example>GET : /Teacher/Update/5</example>
        //GET : /Teacher/Show/{id}
        public ActionResult Update (int id)
        {
            TeachersDataController controller = new TeachersDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);


            return View(SelectedTeacher);
        }



        /// <summary>
        /// Receives a POST request containing information about an existing Teacher in the system, with new values. Conveys this information to the API, and redirects to the "Teacher Show" page of our updated Teacher.
        /// </summary>
        /// <param name="id">Id of the Author to update</param>
        /// <param name="TeacherFname">The updated first name of the Teacher</param>
        /// <param name="TeacherLname">The updated last name of the Teacher</param>
        /// <param name="EmployeeNumber">The updated Employee Number of the Teacher.</param>
        /// <param name="HireDate">The updated Hire Date of the Teacher.</param>
        /// <param name="Salary">The updated Salary of the Teacher.</param>
        /// <returns>A dynamic webpage which provides the current information of the Teacher.</returns>
        /// <example>
        /// POST : /Teacher/Update/10
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"TeacherFname":"Christine",
        ///	"TeacherLname":"Bittle",
        ///	"EmployeeNumber":"12345",
        ///	"HireDate":"2023/01/01"
        ///	"Salary":"1"
        /// }
        /// </example>
        //POST: /Teacher/Show/{id}
        [HttpPost] 
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, string HireDate, string Salary)
        {

            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.HireDate = HireDate;
            TeacherInfo.Salary = Salary;
            TeachersDataController controller = new TeachersDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }


    }

    




}