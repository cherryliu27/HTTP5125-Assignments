using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace HTTP5125_Assignment2.Controllers
{
    //Problem J3: From 1987 to 2013 (2013/Stage1/Junior Problems/J3)

    public class J3Controller : ApiController
    {
        /// <summary>
        /// Receives an integer of a given year and returns the next year with distinct digits.
        /// For example, the year 1987 is a year with distinct digits as no digits are repeated
        /// </summary>
        /// <param name="year">Integer representing the starting year</param>
        /// <returns>
        /// Returns the next distinct year from the starting year
        /// </returns>
        /// <example>
        /// Get api/J3/distinctYear/1987 -> 2013
        /// </example>
        /// <example>
        /// Get api/J3/distinctYear/999 -> 1023
        /// </example>
        /// <example>
        /// Get api/J3/distinctYear/2014 -> 2015
        /// </example>

        [HttpGet]
        [Route("api/J3/distinctYear/{year}")]
        public int distinctYear(int year)
        {
            //Declare variables
            bool stopLoop = false; //Loop Control
            year = year + 1; //Start looping from the next year


            //While loop that includes a nested for loop to check for repeated digits

            while (stopLoop == false)
            {
                bool repeatedDigit = false;

                //When a digit from the outer loop matches a digit from the inner loop, the year is incremented by 1.
                //The while loop continues until no matching digits are found after iterating through both the outer and inner loops.

                for (int i = 0; i < year.ToString().Length; i++)
                {
                    for (int j = i + 1; j < year.ToString().Length; j++)
                    {
                        if (year.ToString()[i] == year.ToString()[j])
                        {
                            repeatedDigit = true;
                            break;
                        }
                    }

                    if (repeatedDigit == true) { break; }
                }

                if (repeatedDigit == false)
                {
                    stopLoop = true;
                    break;
                }
                else { year = year + 1; }
            }

            //returns year with distinct digits
            return year;
        }
    }
}
