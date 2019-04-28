using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer.Model
{
    public class MainPanel
    {
        public Mine mine { get; set; }
        public List<FriendGroup> friend { get; set; }
        public List<Group> group { get; set; }
    }
}
