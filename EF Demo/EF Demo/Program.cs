using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                Student stud = new Student() { StudentName = "New Student", DateOfBirth = new DateTime(1992, 1, 1) };

                ctx.Students.Add(stud);
                ctx.SaveChanges();

                var count = ctx.Students.Count();

                Console.WriteLine("{0} Students", count);
                Console.ReadLine();
            }
        }
    }
}
