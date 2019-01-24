using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFP.Repository.Entities.Entity
{
    [Table("RoleUser")]
    public class RoleUser
    {
        public string UserID { get; set; }
        public int RoleID { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
