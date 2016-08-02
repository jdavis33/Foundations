using System;


namespace Homework4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter An Integer Number Here (Reminder - integers must be greater than 0):");
            string n = Console.ReadLine();
            int x = int.Parse(n);
            int c;
            int sum = 1;

            if (x < 0)
            {
                Console.WriteLine("Please enter an integer value greater than or equal to 0");
                Console.WriteLine("Press Enter to exit and try again.");
            }

            else if (x == 0)
            {
                Console.WriteLine("0! = 0");
                Console.WriteLine("Press Enter to exit and enter another value.");
            }

            else if (x > 0)
                {
                    for (c = 1; c <= x; c++)
                    {
                        int a = sum * c;

                        sum = a;

                        Console.WriteLine("{0}! = {1}", c, a);
                    }

                Console.WriteLine("Press Enter to exit and enter another value.");
                }

                Console.Read();
        }
    }
}
