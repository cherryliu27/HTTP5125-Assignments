using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_CumulativeProject1.Models;
using ZstdSharp.Unsafe;

namespace School_CumulativeProject1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/ListStudent -> returns webpage displaying a full list of students
        /// <returns>
        /// a full list of students in the system
        /// </returns>

        public ActionResult ListStudent()
        {
            List<Student> Students = new List<Student>();

            //Create instance for student data controller object
            StudentDataController Controller = new StudentDataController();
            Students = Controller.ListStudents();

            //Navigates to Views/Student/ListStudent.cshtml
            return View(Students);
        }

        //GET: Student/ShowStudent/{StudentId} -> returns student information that matches user's searched student ID
        /// <summary>
        /// receives input for student id and displays information of the student that matches the id
        /// </summary>
        /// <param name="id">student id integer</param>
        /// <returns>
        /// displays the student's information
        /// </returns>
        public ActionResult ShowStudent(int id)
        {

            //Create new student data controller object
            StudentDataController Controller = new StudentDataController();
            Student SelectedStudent = Controller.FindStudent(id);

            //Navigates to Views/Student/ShowStudent.cshtml
            return View(SelectedStudent);
        }
    }
}