﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Repository.Entities.Entity;

namespace MFP.Repository.Entities.Map
{
    public class V_HeaderMenuMap: EntityTypeConfiguration<V_HeaderMenu>
    {
        public V_HeaderMenuMap()
        {
            HasKey( m => new { m.MenuID,m.UserID});
            ToTable("V_HeaderMenu");
        }
    }
}
