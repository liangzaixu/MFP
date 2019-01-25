using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MFP.Repository.Entities.Entity
{
    [Table("UserLogin")]
    public class UserLogin : IdentityUserLogin<string>
    {
    }
}
