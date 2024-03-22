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
    public class StudentDataController : ApiController
    {
        //Access the MySQL School Database
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns full list of students
        /// </summary>
        /// <returns>
        /// A list of students
        /// </returns>
        /// <example>
        /// GET api/StudentData/ListStudents -> [{"StudentId":1, "StudentFname":"Sarah",
        /// "StudentLname":"Valdez", "StudentNo":"N1678", "EnrollDate":"2018-06-18"},
        /// {"StudentId":2, "StudentFname":"Jennifer", "StudentLname":"Faulkner", "StudentNo":"N1679", "EnrollDate":"2018-08-02"} ]
        /// </example>

        [HttpGet]
        [Route("api/StudentData/ListStudents/")]
        public List<Student> ListStudents()
        {
            //Create a connection instance
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection
            Conn.Open();

            //Create new command for query
            MySqlCommand cmd = Conn.CreateCommand();

            //Write sql query
            cmd.CommandText = "select * from students";

            //Store result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of student names
            List<Student> Students = new List<Student>();

            //Loop through each row from result set and store it into the list
            while (ResultSet.Read())
            {
                Student NewStudent = new Student();
                NewStudent.StudentId = Convert.ToInt32(ResultSet["studentid"]);
                NewStudent.StudentFname = ResultSet["studentfname"].ToString();
                NewStudent.StudentLname = ResultSet["studentlname"].ToString();
                NewStudent.StudentNo = ResultSet["studentnumber"].ToString();
                NewStudent.EnrollDate = ResultSet["enroldate"].ToString();
                Students.Add(NewStudent);
            }

            //close connection
            Conn.Close();

            //Return list of students information
            return Students;

        }


        /// <summary>
        /// Receives student id and return the info of student that matches with that id
        /// </summary>
        /// <param name="StudentId">The Student ID</param>
        /// <returns>
        /// A student object
        /// </returns>
        /// <example>
        /// GET api/studentdata/searchstudent/1 -> 
        /// {"StudentId":1, "StudentFname":"Sarah",
        /// "StudentLname":"Valdez", "StudentNo":"N1678", "EnrollDate":"2018-06-18"}
        /// </example>

        [HttpGet]
        [Route("api/StudentData/FindStudent/{StudentId}")]
        public Student FindStudent(int StudentId)
        {

            //Create connection instance
            MySqlConnection Conn = School.AccessDatabase();

            //Open connection
            Conn.Open();

            //Create command and write query
            MySqlCommand Cmd = Conn.CreateCommand();
            Cmd.CommandText = "select * from students where studentid = " + StudentId;

            //Execute sql command
            MySqlDataReader ResultSet = Cmd.ExecuteReader();

            //store result set into the student object
            Student NewStudent = new Student();
            while (ResultSet.Read())
            {

                NewStudent.StudentId = Convert.ToInt32(ResultSet["studentid"]);
                NewStudent.StudentFname = ResultSet["studentfname"].ToString();
                NewStudent.StudentLname = ResultSet["studentlname"].ToString();
                NewStudent.StudentNo = ResultSet["studentnumber"].ToString();
                NewStudent.EnrollDate = ResultSet["enroldate"].ToString();
            }
            return NewStudent;
        }
    }
}
