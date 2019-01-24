using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Repository.Entities.Entity
{
    [Table("RoleHeaderMenu")]
    public class RoleHeaderMenu
    {
        public int RoleID { get; set; }
        public string MenuID { get; set; }

        public virtual Role Role { get; set; }
        public virtual HeaderMenu HeaderMenu { get; set; }
    }
}
