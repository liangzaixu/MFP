using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entities
{
    public class V_SideMenu
    {
        public string UserID { get; set; }
        public int RoleID { get; set; }
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public int MenuOrder { get; set; }
        public string HeaderMenuID { get; set; }
        public string ParentID { get; set; }
        
        
    }
}
