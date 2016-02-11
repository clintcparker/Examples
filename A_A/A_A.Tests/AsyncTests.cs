using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading.Tasks;
using A_A.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileAccess = A_A.Library.FileAccess;

namespace A_A.Tests
{
    [TestClass]
    public class AsyncTests
    {
        private const long fileSize = 3000000000;

        [TestMethod]
        public async Task TestMethod1()
        {
            var c1 = new WebAccess();
            Printer.Print("Starting Test");
            var length = await c1.AccessTheWebAsync();
            Printer.Print("Checking Length");
            Assert.IsTrue(length > 0);
            Assert.IsTrue(Printer.History.Count > 0);
        }

        [TestMethod]
        public async Task TestCompute()
        {
            Printer.History.Clear();
            for (var i = 0; i < 10000; i++)
            {
                Computations.Example();
                Printer.Print("xxxxxx");
            }

            //first non xxxx value
            var nonXxx = Printer.History.First(x => !(x.Contains("xxxxxx")));
            var nonXIndex = Printer.History.IndexOf(nonXxx);


        }

        [TestMethod]
        public async Task BuildLargeFile()
        {
            var file1 = "../../../../big.txt";
            var file2 = "../../../../bigger.txt";
            if (!FileAlreadyExists(file2))
            {

                using (var writer = new StreamWriter(file2))
                {
                    for (var i = 0; i < 500; i++)
                    {
                        using (var sr = new StreamReader(file1))
                        {
                            await writer.WriteAsync(await sr.ReadToEndAsync());
                        }
                    }
                }
            }
            var file = new System.IO.FileInfo(file2);
            var size = file.Length;
            Assert.IsTrue(size > 3000000000);
        }

        private bool FileAlreadyExists(string path)
        {
            var file = new System.IO.FileInfo(path);
            if (file.Exists && file.Length > fileSize)
            {
                return true;
            }
            if (file.Exists)
            {
                file.Delete();
            }
            return false;
        }

        [TestMethod]
        public async Task TestFileAccess()
        {
            await BuildLargeFile();
            //var lengtgh = await new FileAccess().GetLength("../../../../big.txt");
            var lines = await new FileAccess().GetLines("../../../../bigger.txt");
            Assert.IsTrue(lines > 0);
            Console.WriteLine(lines);
        }

        [TestMethod]
        public async Task SyncDownloads()
        {

            var client = new HttpClient();

            //this endpoint takes 11 seconds to resolve
            var content = await client.GetStringAsync("http://deelay.me/11000/http://deelay.me/img/1000ms.gif");

            //this computation takes about 11 seconds on my machine
            var compute = await Computations.AllocateAsync();

            Assert.IsTrue(compute > 0);
            Assert.IsTrue(content.Length > 0);
        }
        
    }
}
