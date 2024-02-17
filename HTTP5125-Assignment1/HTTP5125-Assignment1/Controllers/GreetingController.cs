using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5125_Assignment1.Controllers
{
    public class GreetingController : ApiController
    {
        /// <summary>
        /// Returns the string "Hello World!"
        /// </summary>
        /// <returns>
        /// "Hello World!"
        /// </returns>
        /// <example>
        /// GET: localhost:xx/api/Greeting => "Hello World!" 
        /// </example>

        public string GET()
        {
            return "Hello World!";
        }


        /// <summary>
        /// Recieves an integer input number and returns a string greeting the input number of people
        /// </summary>
        /// <param name="id">The input number</param>
        /// <returns>
        /// "Greetings to {id} people!"
        /// </returns>
        /// <example>
        /// GET: localhost:xx/api/Greeting/3 => "Greetings to 3 people!"
        /// </example>
        /// <example>
        /// GET: localhost:xx/api/Greeting/0 => "Greetings to 0 people!"
        /// </example>

        public string get(int id)
        {
            return "Greetings to " + id + " people!";
        }

    }
}
