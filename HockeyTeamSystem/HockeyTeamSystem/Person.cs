using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; //For regular expressions  ---- Regex

namespace HockeyTeamSystem
{
    public class Person
    {
        //Define an auto-implemented property with a private set for the full name

        //A private set property cannot be assigned a value in the constructor
        //or an instance method
        public string FullName { get; private set; }

        //Define a greedy constructor that takes a fullName as a parameter

        //Constructors are used to create instance of an object
        //and also to assign meaningful values to the fields/properties of the class.
        public Person(string fullName)
        {
            //Validate that the fullName parameter is not null, whitespaces or an empty string
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException("Person FullName is required");
            }
            //Validate that the fullName parameter contains only letter a-z
            //and one or more space character
            //@"" is literal string where the charaters have no meaning
            //^ start of input
            //$ end of input
            // [ ] range of charaters
            //{3,} at least 3
            //{,2} up to 2
            // range a-z or A-Z; must have at least 3 letters, and max 2 whitespace
            var fullNameCheck = new Regex(@"^[a-zA-Z \-]{5,}$");
            if (fullNameCheck.IsMatch(fullName) == false)
            {
                throw new ArgumentException("Person FullName must contain at least 5 characters.");
            }

            //this. means refers to the current object and it is
            //used to access a fields
            //or property of the current object
            this.FullName = fullName.Trim(); //this. could be followed with a data field name or a property name
        }


    }
}
