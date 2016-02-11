using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_A.Library
{
    public static class Computations
    {
        public static async void Example()
        {
            // This method runs asynchronously.
            int t = await Task.Run(() => Allocate());
            Printer.Print("Compute: " + t);
        }

        public static int Allocate()
        {
            // Compute total count of digits in strings.
            int size = 0;
            for (int z = 0; z < 100; z++)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    string value = i.ToString();
                    size += value.Length;
                }
            }
            return size;
        }

        public static Task<int> AllocateAsync()
        {
            // Compute total count of digits in strings.
            int size = 0;
            for (int z = 0; z < 100; z++)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    string value = i.ToString();
                    size += value.Length;
                }
            }
            return Task.FromResult(size);
        }
    }
}
