using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_A.Library
{
    public class FileAccess
    {
        public async Task<int> GetLength(string filePath)
        {
            var sr = new StreamReader(filePath);

            var chars = sr.ReadToEnd();

            return chars.Length;
        }

        public async Task<int> GetLines(string bigTxt)
        {
            int lines = 0;
            var sr = new StreamReader(bigTxt);
            while (!sr.EndOfStream)
            {
                await sr.ReadLineAsync();
                lines++;
            }
            return lines;
        }
    }
}
