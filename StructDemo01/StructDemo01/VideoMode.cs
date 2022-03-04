using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo01
{
    internal class VideoMode
    {
       public Resolution Resolutin { get; set; } = new Resolution(1080,1090);
        public bool Interlaced { get; set; } = false;
        public double FrameRate { get; set; } = 0;

        // ? means you can assign a null to it. 
        // ? is a nullable type
        public string? Name { get; set; } = null;
        
    }
}
