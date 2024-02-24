using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Security;

namespace HTTP5125_Assignment2.Controllers
{
    public class J2Controller : ApiController
    {

        //Problem J2: Vote Count (2014/Stage1/Junior Problems/J2)

        /// <summary>
        /// A vote is held after a singing competition between Singer A and Singer B. 
        /// The program receives two input including the total number of votes and the vote sequence (e.g. AAABB) for each singer.
        /// The program determines the winner by counting the votes for each singer
        /// </summary>
        /// <param name="numOfVotes">Integer representing the total number of votes received</param>
        /// <param name="sequence">String representing the vote sequence composed of 'A' and 'B' characters, 
        /// where each 'A' or 'B' indicates a vote for a specific singer (e.g., AAABBA).".</param>
        /// <returns>
        /// Returns a string representing the winner and outcome of the competition 
        /// If there are more A votes than B Votes -> B
        /// If there are more B votes than A Votes -> A
        /// If there are an equal number of A Votes and B Votes -> Tie </returns>
        /// <example>
        /// GET ../api/J2/Vote/6/ABBABB -> B
        /// </example>
        /// <example>
        /// GET ../api/J2/Vote/6/AAABBB -> Tie
        /// </example>

        [HttpGet]
        [Route("api/J2/Vote/{numOfVotes}/{sequence}")]
        public string Vote(int numOfVotes, string sequence)
        {
            //Declare variables
            int countA = 0;
            int countB = 0;

            //Calculate total votes of singer A and singer B received respectively
            for (int i = 0; i < numOfVotes; i++)
            {
                if (sequence[i].ToString() == "A")
                {
                    countA++;
                }
                else if (sequence[i].ToString() == "B")
                {
                    countB++;
                }
            }

            //Determines the winner and outcome of the competition
            if (countA > countB)
            {
                return "A";
            }
            else if (countA < countB)
            {
                return "B";
            }
            else
            {
                return "Tie";
            }
        }


    }
}
