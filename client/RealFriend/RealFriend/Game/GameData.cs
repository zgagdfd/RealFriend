using System.Collections.Generic;

namespace RealFriend.Game
{
    public class GameData
    {
        public int id { get; set; }
        public string name { get; set; }
        public int initiator { get; set; }
        public List<int> participants { get; set; }
        public bool is_private { get; set; } = false;
        // public string status { get; set; }
        // public string create_time { get; set; }
        public string start_time { get; set; }
        public string type { get; set; }
        public string introduction { get; set; }
    }
}
