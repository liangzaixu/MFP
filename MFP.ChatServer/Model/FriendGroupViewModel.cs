using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer.Model
{
    public class FriendGroupViewModel
    {
        public FriendGroupViewModel()
        {
            list = new List<UserViewModel>();
        }

        public string id { get; set; }
        public string groupname { get; set; }
        public string ownerid { get; set; }
        public List<UserViewModel> list { get; set; }
    }
}
