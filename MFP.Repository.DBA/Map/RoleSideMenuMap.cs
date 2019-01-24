using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MFP.Repository.Entities.Entity;

namespace MFP.Repository.Entities.Map
{
    public class RoleSideMenuMap:EntityTypeConfiguration<RoleSideMenu>
    {
        public RoleSideMenuMap()
        {
            HasKey(m => new {m.MenuID, m.RoleID});
        }
    }
}
