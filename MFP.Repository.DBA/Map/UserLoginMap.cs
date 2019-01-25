using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MFP.Repository.Entities.Entity;


namespace MFP.Repository.Entities.Map
{
    public class UserLoginMap : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginMap()
        {
            HasKey(m => new { m.UserId, m.ProviderKey,m.LoginProvider });
            ToTable("UserLogin");

        }
    }
}
