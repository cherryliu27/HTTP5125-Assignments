using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5125_Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// Receives 4 intergers input representing a choice from each menu category and returns the total calorie count
        /// </summary>
        /// <param name="burger">Integer representing the index burger choice</param>
        /// <param name="drink">Integer representing the index drink choice</param>
        /// <param name="side">Integer representing the index side choice</param>
        /// <param name="dessert">Integer representing the dessert choice</param>
        /// <returns>
        /// Returns a string with total calorie count -> "Your total calorie count is {total}"
        /// </returns>
        /// <example>
        /// GET api/J1/Menu/4/4/4/4 -> "Your total calorie count is 0"
        /// </example>
        /// <example>
        /// GET api/J1/Menu/1/2/3/4 -> "Your total calorie count is 691"
        /// </example>

        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            //Declare variables
            int totalBurger = 0;
            int totalDrink = 0;
            int totalSide = 0;
            int totalDessert = 0;

            //Find the calorie count of the burger choice selected
            if (burger == 1)
            {
                totalBurger = 461;
            }
            else if (burger == 2)
            {
                totalBurger = 431;
            }
            else if (burger == 3)
            {
                totalBurger = 420;
            }

            //Find the calorie count of the drink choice selected
            if (drink == 1)
            {
                totalDrink = 130;
            }
            else if (drink == 2)
            {
                totalDrink = 160;
            }
            else if (drink == 3)
            {
                totalDrink = 180;
            }

            //Find the calorie count of the side order choice selected
            if (side == 1)
            {
                totalSide = 100;
            }
            else if (side == 2)
            {
                totalSide = 57;
            }
            else if (side == 3)
            {
                totalSide = 70;
            }


            //Find the calorie count of the dessert choice selected
            if (dessert == 1)
            {
                totalDessert = 130;
            }
            else if (dessert == 2)
            {
                totalDessert = 266;
            }
            else if (dessert == 3)
            {
                totalDessert = 75;
            }

            //Returns string displaying total amount of calorie count
            return $"Your total calorie count is {totalBurger + totalDrink + totalSide + totalDessert}";


        }
    }
}
