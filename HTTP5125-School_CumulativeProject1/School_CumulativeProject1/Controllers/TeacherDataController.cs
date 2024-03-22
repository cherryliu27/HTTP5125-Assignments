﻿using MySql.Data.MySqlClient;
using School_CumulativeProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace School_CumulativeProject1.Controllers
{
    public class TeacherDataController : ApiController
    {
        //Access the MySQL School Database
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns a list of teachers in the school that matches with a search key (filter by name, hiredate, salary)
        /// </summary>
        /// <returns>
        /// A list of teachers that matches with a search key. If search key is null, a full list of teachers is returned
        /// </returns>
        /// <param name="SearchKey">The search key for searching teachers</param>
        /// <example>
        /// GET api/TeacherData/ListTeachers/Alexander -> [{"TeacherId":1, "TeacherFname":"Alexander",
        /// "TeacherLname":"Bennett", "EmployeeNo":"T378", "HireDate":"2016-08-05 00:00:00",
        /// "Salary":55.30}]
        /// </example>
        /// <example>
        /// GET api/TeacherData/ListTeachers -> [{"TeacherId":1, "TeacherFname":"Alexander",
        /// "TeacherLname":"Bennett", "EmployeeNo":"T378", "HireDate":"2016-08-05 00:00:00",
        /// "Salary":55.30}, {"TeacherId":2, "TeacherFname":"Caitlin",
        /// "TeacherLname":"Cummings", "EmployeeNo":"T381", "HireDate":"2014-06-10 00:00:00",
        /// "Salary":62.77}]
        /// </example>


        /// 
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public List<Teacher> ListTeachers(string SearchKey=null)
        {
            //Create a connection instance
            MySqlConnection Conn = School.AccessDatabase();


            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command query
            MySqlCommand cmd = Conn.CreateCommand();

            //Write sql query
            cmd.CommandText = "select * from teachers where teacherfname like @SearchKey or teacherlname like @SearchKey or salary like @SearchKey or hiredate like @SearchKey;";

            //define searchkey
            cmd.Parameters.AddWithValue("@SearchKey", "%" + SearchKey + "%");
            cmd.Prepare();

            //Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of teacher names
            List<Teacher> Teachers = new List<Teacher>();

            //Loop through each row from result set
            while (ResultSet.Read())
            {

                //Create new teacher object to hold above information
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                NewTeacher.TeacherFname = ResultSet["teacherfname"].ToString();
                NewTeacher.TeacherLname = ResultSet["teacherlname"].ToString();
                NewTeacher.EmployeeNo = ResultSet["employeenumber"].ToString();
                NewTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                NewTeacher.Salary = decimal.Parse(ResultSet["salary"].ToString());

                Teachers.Add(NewTeacher);
            }

            //close connection
            Conn.Close();

            //Return list of teacher information
            return Teachers;

        }


        /// <summary>
        /// Receives teacher id and return teacher information that matches that id
        /// </summary>
        /// <param name="TeacherId">The teacher id primary key</param>
        /// <returns>
        /// A teacher object
        /// </returns>
        /// <example>
        /// GET api/teacherdata/searchteacher/1 -> 
        /// {"TeacherId":1, "TeacherFname":"Alexander",
        /// "TeacherLname":"Bennett", "EmployeeNo":"T378", "HireDate":"2016-08-05 00:00:00",
        /// "Salary":55.30}
        /// </example>

        [HttpGet]
        [Route("api/TeacherData/FindTeacher/{TeacherId}")]
        public Teacher FindTeacher(int TeacherId)
        {

            //Create connection instance
            MySqlConnection Conn = School.AccessDatabase();

            //Open connection
            Conn.Open();

            //Establish new command and write query
            MySqlCommand Cmd = Conn.CreateCommand();
            Cmd.CommandText = "select * from teachers where teacherid = " + TeacherId;

            //Execute sql command
            MySqlDataReader ResultSet = Cmd.ExecuteReader();

            //put information into teacher object
            Teacher NewTeacher = new Teacher();

            while (ResultSet.Read())
            {

                NewTeacher.TeacherId = Convert.ToInt32(ResultSet["teacherid"]); 
                NewTeacher.TeacherFname = ResultSet["teacherfname"].ToString();
                NewTeacher.TeacherLname = ResultSet["teacherlname"].ToString();
                NewTeacher.EmployeeNo = ResultSet["employeenumber"].ToString();
                NewTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                NewTeacher.Salary = decimal.Parse(ResultSet["salary"].ToString());
            }
            return NewTeacher;
        }

    }
}
