using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5125_Assignment1.Controllers
{

    public class AddTenController : ApiController
    {

        /// <summary>
        /// Receives an integer input number and returns the number plus 10
        /// </summary>
        /// <param name="id">The input number</param>
        /// <returns>
        /// The input number plus 10
        /// </returns>
        /// <example>
        /// GET: localhost:xx/api/AddTen/21 => 31
        /// </example>
        /// <example>
        /// GET: localhost:xx/api/AddTen/-9 => 1
        /// </example>

        public int get(int id)
        {
            return id + 10;
        }

    }
}
