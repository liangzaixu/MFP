using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MFP.Repository.Entities.Entity
{
    [Table("UserRole")]
    public class UserRole : IdentityUserRole<string>
    {
    }
}
