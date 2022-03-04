using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo02
{
    internal class Instructor
    {
        //Data fileds and properties
        public string Name { get; set; }
        public EmploymentType EmploymentType { get; private set; } = EmploymentType.FullTime;

        //Constructor
        public Instructor(string Name, EmploymentType employment)
        {
            if(Utilities.IsVaildNameLength(Name,5) == false)
            {
                throw new Exception("Instructor Name must not be null or empty and must contain 5 or more character length");
            }
        }
        
    }
}
