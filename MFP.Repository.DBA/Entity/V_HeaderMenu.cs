using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Repository.DBA.Entity
{
    public class V_HeaderMenu
    {
        public string UserID { get; set; }
        public int RoleID { get; set; }
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public string MenuOrder { get; set; }
    }
}
