using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFP.Repository.Entities.Entity
{
    [Table("RoleDetailAction")]
    public class RoleDetailAction
    {
        public int RoleID { get; set; }
        public string ActionID { get; set; }

        public virtual Role Role { get; set; }

        public virtual DetailAction DetailAction { get; set; }
    }
}
