using MySql.Data.MySqlClient;
using School_CumulativeProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School_CumulativeProject1.Controllers
{
    public class CourseDataController : ApiController
    {
        //Access the MySQL School Database
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns full list of courses
        /// </summary>
        /// <returns>
        /// A list of courses
        /// </returns>
        /// <example>
        /// GET api/CourseData/ListCourses -> [{"CourseId":1, "CourseCode":"http5101",
        /// "TeacherId":1, "StartDate":"2018-09-04", "FinishDate":"2018-12-14", "ClassName":"Web Application Development"},
        /// {"CourseId":2, "CourseCode":"http5102",
        /// "TeacherId":2, "StartDate":"2018-09-04", "FinishDate":"2018-12-14", "ClassName":"Project Management"}]
        /// </example>

        [HttpGet]
        [Route("api/CourseData/ListCourses/")]
        public List<Course> ListCourses()
        {
            //Create a connection instance
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection
            Conn.Open();

            //Create new command for query
            MySqlCommand cmd = Conn.CreateCommand();

            //Write sql query
            cmd.CommandText = "select * from classes";

            //Store result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of course names
            List<Course> Courses = new List<Course>();

            //Loop through each row from result set and store it into the list
            while (ResultSet.Read())
            {
                Course NewCourse = new Course();
                NewCourse.CourseId = Convert.ToInt32(ResultSet["classid"]);
                NewCourse.CourseCode = ResultSet["classcode"].ToString();
                NewCourse.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                NewCourse.StartDate = ResultSet["startdate"].ToString();
                NewCourse.FinishDate = ResultSet["finishdate"].ToString();
                NewCourse.CourseName = ResultSet["classname"].ToString();
                Courses.Add(NewCourse);
            }

            //close connection
            Conn.Close();

            //Return list of course information
            return Courses;

        }


        /// <summary>
        /// Receives input of course id and return the course info that matches that id
        /// </summary>
        /// <param name="CourseId">The course ID</param>
        /// <returns>
        /// A course object
        /// </returns>
        /// <example>
        /// GET api/coursedata/findcourse/1 -> 
        /// {"CourseId":1, "CourseCode":"http5101",
        /// "TeacherId":1, "StartDate":"2018-09-04", "FinishDate":"2018-12-14", "ClassName":"Web Application Development"}
        /// </example>

        [HttpGet]
        [Route("api/CourseData/FindCourse/{courseId}")]
        public Course FindCourse(int CourseId)
        {

            //Create connection instance
            MySqlConnection Conn = School.AccessDatabase();

            //Open connection
            Conn.Open();

            //Create command and write query
            MySqlCommand Cmd = Conn.CreateCommand();
            Cmd.CommandText = "select * from classes where classid = " + CourseId;

            //Execute sql command
            MySqlDataReader ResultSet = Cmd.ExecuteReader();

            //store result set into the course object
            Course NewCourse = new Course();
            while (ResultSet.Read())
            {
                NewCourse.CourseId = Convert.ToInt32(ResultSet["classid"]);
                NewCourse.CourseCode = ResultSet["classcode"].ToString();
                NewCourse.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                NewCourse.StartDate = ResultSet["startdate"].ToString();
                NewCourse.FinishDate = ResultSet["finishdate"].ToString();
                NewCourse.CourseName = ResultSet["classname"].ToString();
            }
            return NewCourse;
        }
    }
}
