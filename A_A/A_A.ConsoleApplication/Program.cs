using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_A.Library;

namespace A_A.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Asynchronous work
                Computations.Example();

                //Alternate synchronous work
                string result = Console.ReadLine();
                Printer.Print("You typed: "+result);

            }
        }
    }
}
