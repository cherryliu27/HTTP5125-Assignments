using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5125_Assignment1.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// Receives an integer input number and returns a boolean value after multiplying 
        /// the input number by 3, and adding 2, then checking if the result is greater than 20.
        /// </summary>
        /// <param name="id">The input number</param>
        /// <returns>
        /// A boolean value for ({id} + 3) * 2 - 1 > 20
        /// </returns>
        /// <example>
        /// GET: localhost:xx/api/NumberMachine/10 => true
        /// </example>
        /// <example>
        /// GET: localhost:xx/api/NumeberMachine/-5 => false
        /// </example>
        /// <example>
        /// GET: localhost:xx/api/NumberMachine/30 => true
        /// </example> 

        public bool get(int id)
        {
            return (id + 3) * 2 - 1 > 20;
        }
    }
}
