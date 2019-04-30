using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MFP.Repository.Entities.Entity
{
    [Table("Role")]
    public class Role : IdentityRole<string, UserRole>
    {

    }
}
