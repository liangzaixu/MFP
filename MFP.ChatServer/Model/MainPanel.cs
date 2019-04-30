using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer.Model
{
    public class MainPanelViewModel
    {
        public MineViewModel mine { get; set; }
        public List<FriendGroupViewModel> friend { get; set; }
        public List<GroupViewModel> group { get; set; }
    }
}
