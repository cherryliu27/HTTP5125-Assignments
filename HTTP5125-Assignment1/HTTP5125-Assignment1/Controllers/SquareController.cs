using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5125_Assignment1.Controllers
{
    public class SquareController : ApiController
    {

        /// <summary>
        /// Receives an integer input number and returns the square of the number
        /// </summary>
        /// <param name="id">The input number</param>
        /// <returns>
        /// The square of the input number
        /// </returns>
        /// <example>
        /// GET: localhost:xx/api/Square/-2 => 4
        /// </example>
        /// <example>
        /// GET: localhost: xx/api/Square/10 => 100
        /// </example>

        public int GET(int id)
        {
            return id * id;
        }

    }
}
