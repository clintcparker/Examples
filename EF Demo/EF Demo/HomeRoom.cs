using System.Collections.Generic;

namespace EF_Demo
{
    public class HomeRoom
    {
        public HomeRoom()
        {

        }
        public int HomeRoomId { get; set; }
        public string RoomName { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}