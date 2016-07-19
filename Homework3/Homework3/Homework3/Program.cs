using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main()
        {
            //Enter Seconds Here//
            int x = 234833;
            //Enter Seconds Here//

            //convert to days//
            int d = x / 86400;

            //find the remainder of seconds//
            int dsr = (d * 86400 - x);
            
            
            //convert remaining seconds to hours//
            int h = dsr / 3600;
           

            //find the remainder of seconds//
            int hsr = (h * 3600 - dsr);

            //convert remaining seconds to minutes//
            int m = hsr / 60;

            //find the remainder of seconds//
            int msr = (m * 60 - hsr);


            //write converted time to console window//
            if (d < 0) { Console.WriteLine("{0} days", d * -1); }
            if (d >= 0) { Console.WriteLine("{0} days", d); }
            if (h < 0) { Console.WriteLine("{0} hours", h * -1); }
            if (h >= 0) { Console.WriteLine("{0} hours", h); }
            if (m < 0) { Console.WriteLine("{0} minutes", m * -1); }
            if (m >= 0) { Console.WriteLine("{0} minutes", m); }
            if (msr < 0) { Console.WriteLine("{0} seconds", msr * -1); }
            if (msr >= 0) { Console.WriteLine("{0} seconds", msr); }
            Console.ReadLine();

        }
    }
}
