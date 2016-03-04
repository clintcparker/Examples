using System.Data.Entity;

namespace EF_Demo
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<HomeRoom> HomeRooms { get; set; }

    }
}