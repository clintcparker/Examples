using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_A.Library
{
    public static class Printer
    {
        private static readonly List<string> HistoryList = new List<string>(); 
        public static void Print(string strIn)
        {
            var str = $"@{strIn} \t\t {DateTime.UtcNow.ToLongTimeString()}";
            HistoryList.Add(str);
            Debug.WriteLine(str);
        }

        public static List<string> History => HistoryList;
        
    }
}
