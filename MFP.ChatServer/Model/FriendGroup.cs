using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer.Model
{
    public class FriendGroup
    {

        public FriendGroup()
        {
            list = new List<User>();
        }
        public string groupname { get; set; }
        public string id { get; set; }
        public List<User> list { get; set; }
        public string ownerid { get; set; }
    }
}
