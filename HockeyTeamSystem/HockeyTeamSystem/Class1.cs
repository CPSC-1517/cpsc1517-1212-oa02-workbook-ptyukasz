
using System.Text.RegularExpressions;
namespace HockeyTeamSystem
{
    public class Person
    { 
        public string FullName { get; private set; }
        public Person(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentNullException("Person FullName is required");

            //Validate that the full name parameter contains only
            //letters a-z and up to two space characters
            //@ "" is literal string where there is no meaing to any of characters
            // ^ start of input
            // $ end of input
            // [] range of characters
            // {3,} at least 3
            //{,2) up to 2

            var fullNameCheck = new Regex(@"^[a-zA-Z] [ ] {3,},$");
            if (fullNameCheck.IsMatch(fullName) == false)
            {
                throw new ArgumentException("Person FullName must contain at least 3 characters and a maximum of two spaces");

            }

            // The this keyword refers to the current object
            // and it is used to access a field or property
            //of the current object


            this.FullName = fullName.Trim();

        }

        public override string ToString() 
        {
            return $"{FullName}";
        }
           
        }

}
}


       


