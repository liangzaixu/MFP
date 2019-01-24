using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MFP.Repository.Entities.Entity;

namespace MFP.Repository.Entities.Map
{
    public class V_DetailActionMap:EntityTypeConfiguration<V_DetailAction>
    {
        public V_DetailActionMap()
        {
            HasKey(m => new { m.ActionID, m.SideMenuID, m.UserID });

        }
    }
}
