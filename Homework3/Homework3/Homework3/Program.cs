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
            int x = 34000;
            int s = x;
            int m = x / 60;
            int h = x / 600;
            int d = x / 6000;

            Console.WriteLine("{0} seconds", s);
            Console.WriteLine("{0} minutes", m);
            Console.WriteLine("{0} hours", h);
            Console.WriteLine("{0} days", d);
            Console.ReadLine();

        }
    }
}
