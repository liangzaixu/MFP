using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MFP.Repository.DBA.Entity;

namespace MFP.Repository.DBA.Map
{
    public class V_SideMenuMap:EntityTypeConfiguration<V_SideMenu>
    {
        public  V_SideMenuMap()
        {
            HasKey(m => new { m.MenuID, m.UserID });
            ToTable("V_SideMenu");
        }
    }
}
