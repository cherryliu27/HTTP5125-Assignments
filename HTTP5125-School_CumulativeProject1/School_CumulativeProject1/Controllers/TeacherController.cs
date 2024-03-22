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
    }
}