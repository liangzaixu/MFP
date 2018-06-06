using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MFP.Repository.DBA.Entity;

namespace MFP.Repository.DBA.Map
{
    public class RoleDetailActionMap:EntityTypeConfiguration<RoleDetailAction>
    {
        public RoleDetailActionMap()
        {
            ToTable("RoleDetailAction");
            HasKey(m => new { m.ActionID, m.RoleID});
        }
    }
}
