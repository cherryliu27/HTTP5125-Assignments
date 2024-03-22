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
    public class CourseController : Controller
    {
        // GET: Course/ListCourse -> returns webpage displaying a list of courses
        /// <returns>
        /// a full list of courses 
        /// </returns>

        public ActionResult ListCourse()
        {
            List<Course> Courses = new List<Course>();

            //Create instance for course data controller object
            CourseDataController Controller = new CourseDataController();
            Courses = Controller.ListCourses();

            //Navigates to Views/Course/ListCourse.cshtml
            return View(Courses);
        }

        //GET: Course/ShowCourse/{CourseId} -> returns course information that matches user's searched course ID
        /// <summary>
        /// receives input for course id and displays the course information that matches the id
        /// </summary>
        /// <param name="id">course id integer</param>
        /// <returns>
        /// displays the course information
        /// </returns>
        public ActionResult ShowCourse(int id)
        {

            //Create new course data controller object
            CourseDataController Controller = new CourseDataController();
            Course SelectedCourse = Controller.FindCourse(id);

            //Navigates to Views/Course/ShowCourse.cshtml
            return View(SelectedCourse);
        }
    }
}