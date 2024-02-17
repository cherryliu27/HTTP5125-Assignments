using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5125_Assignment1.Controllers
{
    public class HostingCostController : ApiController
    {
        /// <summary>
        /// Receives an input number of days elapsed since the beginning of hosting and 
        /// returns a string description of the total hosting cost calculation
        /// </summary>
        /// <param name="id">input number of days elapsed since the beginning of hosting</param>
        /// <returns>
        /// Returns 3 lines of strings describing the calculation of
        ///     1. Hosting cost by number of fortnights
        ///     2. 13% Tax of the hosting cost 
        ///     3. Total hosting cost with tax included
        /// </returns>
        /// <example>
        /// GET: localhost:xx/api/HostingCost/0
        /// => 
        /// "1 fortnights at $5.50/FN = $5.50 CAD"
        /// "HST 13% = $0.72 CAD"
        /// "Total = $6.22 CAD"
        /// </example>
        /// <example>
        /// GET: localhost:xx/api/HostingCost/15
        /// => 
        /// "2 fortnights at $5.50/FN = $11.00 CAD"
        /// "HST 13% = $1.43 CAD"
        /// "Total = $12.43 CAD"
        /// </example>

        //IEnumerable <string> is used to returned multiple lines of strings.
        public IEnumerable<string> get(int id)
        {
            //Declare variables
            int days = id / 14 + 1;
            double cost = days * 5.50;
            double tax = cost * 0.13;
            double total = cost + tax;

            //Concat return text and calculated cost
            //All calculated cost is converted to 2 decimal display.
            return new string[] {
                days + " fortnights at $5.50/FN = $" + cost.ToString("F2") + " CAD",
                "HST 13% = $" + tax.ToString("F2") + " CAD",
                "Total = $" + total.ToString("F2") + " CAD" };

        }
    }
}
