using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Dal.Entities
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

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<HeaderMenu> HeaderMenus { get; set; }

        public virtual ICollection<SideMenu> SideMenus { get; set; }
    }
}
