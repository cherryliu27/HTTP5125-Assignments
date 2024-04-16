using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using School_CumulativeProject1.Models;
using ZstdSharp.Unsafe;

namespace School_CumulativeProject1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/ListTeacher/{SearchKey} -> returns a webpage displaying a list of teachers 
        /// <summary>
        /// receives input of text/search key and displays webpage of full list of teachers that matches the search key (filter by name, hiredate, salary)
        /// </summary>
        /// <returns>
        /// List of teachers that matches the search key</returns>

        public ActionResult ListTeacher(string SearchKey)
        {

            List<Teacher> Teachers = new List<Teacher>();

            //Create instance of teacher data controller object
            TeacherDataController Controller = new TeacherDataController();
            Teachers = Controller.ListTeachers(SearchKey);

            //Navigate to Views/Teacher/ListTeacher.cshtml
            return View(Teachers);
        }

        //GET: Teacher/ShowTeacher/{TeacherId} -> returns a web page displaying the teacher's information that matches the user's searched teacher ID
        /// <summary>
        /// receives input of teacher id and displays the corresponding information of the teacher that matches the id
        /// </summary>
        /// <param name="id">the teacher id</param>
        /// <returns>displays the teachers information</returns>
        public ActionResult ShowTeacher(int id)
        {

            //Create instance of teacher data controller object
            TeacherDataController Controller = new TeacherDataController();
            Teacher SelectedTeacher = Controller.FindTeacher(id);

            //Navigate to Views/Teacher/ShowTeacher.cshtml
            return View(SelectedTeacher);
        }

        //GET: Teacher/New -> Shows a new teacher web page for user to create new teacher
        /// <summary>
        /// Shows a page for adding new teacher information
        /// </summary>
        /// <returns>Displays form allowing user to input new teacher information</returns>
        public ActionResult New()
        {
            //Navigate to Views/Teacher/New.cshtml
            return View();

        }


        /// <summary>
        /// Creates new teacher with user provided information to the database
        /// </summary>
        /// <param name="TeacherFName">teacher first name</param>
        /// <param name="TeacherLName">teacher last name</param>
        /// <param name="EmployeeNo">teacher's employee number</param>
        /// <param name="HireDate">teacher's hire date</param>
        /// <param name="Salary">teacher's salary</param>
        /// <returns>Redirect to the ListTeacher cshtml to display the updated list of teachers</returns>
        //POST: Teacher/Create -> Redirects to listteacher.cshtml
        [HttpPost]
        public ActionResult Create(string TeacherFName, string TeacherLName, string EmployeeNo, DateTime HireDate, decimal Salary)
        {

            //Add article in
            TeacherDataController TeacherController = new TeacherDataController();

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFName;
            NewTeacher.TeacherLname = TeacherLName;
            NewTeacher.EmployeeNo = EmployeeNo;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary=Salary;

            TeacherController.AddTeacher(NewTeacher);

            //redirects to ListTeacher.cshtml
            return RedirectToAction("ListTeacher");
        }



        /// <summary>
        /// outputs a web page that allows user to confirm deletion of the specified teacher id
        /// </summary>
        /// <param name="id">the teache id</param>
        /// <returns>Returns a view displaying the information of the selected teacher for delete confirmation</returns>
        //GET: /Teacher/DeleteConfirm/{id} -> Outputs a web page that allows user to confirm deletion
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController TeacherController = new TeacherDataController();
            Teacher SelectedTeacher = TeacherController.FindTeacher(id);
            return View(SelectedTeacher);
        }



        /// <summary>
        /// Deletes the teacher of the specified id then redirect to the ListTeacher.cshtml
        /// </summary>
        /// <param name="id">the teacher id</param>
        /// <returns>Redirects to ListTeacher.cshtml after deleting the specified teacher.</returns>
        //POST: /Teacher/Delete/{id} -> Reroute to ListTeacher.cshtml
        [HttpPost]
        public ActionResult Delete(int id) 
        {
            TeacherDataController TeacherController = new TeacherDataController();
            TeacherController.DeleteTeacher(id);
            return RedirectToAction("ListTeacher");
        }




        //GET: /Teacher/Update/{teacherid} -> Allows user to update informaiton of teacher
        /// <summary>
        /// Shows a page for adding new teacher information
        /// </summary>
        /// <param name="id">the teacher id to be updated</param>
        /// <returns>View containing the information of the selected teacher for updating</returns>
        public ActionResult Update(int id) { 

            TeacherDataController Controller = new TeacherDataController();
            Teacher SelectedTeacher = Controller.FindTeacher(id);
            //Redirects to Views/Teacher/Update.cshtml
            return View(SelectedTeacher); 
        }


        //POST: /Teacher/Edit/{teacherid} -> Receives teacher information to update
        /// <summary>
        /// Receives POST request of the updated teacher information, updates teacher information and redirects to the corresponding teacher's page
        /// </summary>
        /// <param name="id">updated teacher id</param>
        /// <param name="TeacherFname">updated teacher first name</param>
        /// <param name="TeacherLname">updated teacher last name</param>
        /// <param name="EmployeeNo">updated employee number</param>
        /// <param name="HireDate">updated hiredate</param>
        /// <param name="Salary">updated salary</param>
        /// <returns>Returns a redirection to the teacher's information page of that teacher id</returns>

        [HttpPost]
        public ActionResult Edit(int id, string TeacherFname, string TeacherLname, string EmployeeNo, DateTime HireDate, decimal Salary) {

            TeacherDataController Controller = new TeacherDataController();

            Teacher UpdatedTeacher = new Teacher();
            UpdatedTeacher.TeacherFname = TeacherFname;
            UpdatedTeacher.TeacherLname = TeacherLname;
            UpdatedTeacher.EmployeeNo = EmployeeNo;
            UpdatedTeacher.HireDate = HireDate;
            UpdatedTeacher.Salary = Salary;

            Controller.UpdateTeacher(id,UpdatedTeacher);

            //Redirects to /Views/Teacher/ShowTeacher/{TeacherId}
            return RedirectToAction("ShowTeacher/"+id);
        }
    }
}