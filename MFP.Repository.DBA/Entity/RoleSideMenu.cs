using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFP.Repository.DBA.Entity
{
    [Table("RoleSideMenu")]
    public class RoleSideMenu
    {
        public int RoleID { get; set; }
        public string MenuID { get; set; }

        public virtual Role Role { get; set; }
        public virtual SideMenu SideMenu { get; set; }
    }
}
