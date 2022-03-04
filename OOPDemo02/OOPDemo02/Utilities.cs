using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo02
{
    //A static class prevents the creation of an object(instance) of the class
    internal class Utilities
    {
        public static bool IsVaildNameLength(string name, int minLength)
        {
            bool isVaild = false;

            if(!string.IsNullOrEmpty(name) && name.Trim().Length >= minLength)
            {
                isVaild = true;
            }
            return isVaild;
        }

    }
}
