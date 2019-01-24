using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFP.Repository.Entities.Entity
{
    public class V_DetailAction
    {
        public string UserID { get; set; }

        public int RoleID { get; set; }

        public string ActionID { get; set; }

        public string ActionName { get; set; }

        public string Title { get; set; }

        public string SideMenuID { get; set; }

    }
}
