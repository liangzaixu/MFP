using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MFP.Repository.DBA.Entity
{
    [Table("Role")]
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoleID { get; set; }

        [Column(TypeName ="varchar")]
        [Required,StringLength(30)]
        public string RoleName { get; set; }

        //public virtual ICollection<User> Users { get; set; }

        //public virtual ICollection<HeaderMenu> HeaderMenus { get; set; }

        //public virtual ICollection<SideMenu> SideMenus { get; set; }

        //public virtual ICollection<DetailAction> DetailActions { get; set; }

        public virtual ICollection<RoleUser> Users { get; set; }

        public virtual ICollection<RoleDetailAction> RoleDetailAction { get; set; }

        public virtual ICollection<RoleHeaderMenu> RoleHeaderMenu { get; set; }

        public virtual ICollection<RoleSideMenu> RoleSideMenu { get; set; }
    }
}
