using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Repository.Entities.Entity
{
    [Table("HeaderMenu")]
    public class HeaderMenu
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string MenuID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string MenuName { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(200)]
        public string Url { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string IconUrl { get; set; }

        [Required]
        public int MenuOrder { get; set; }

        public virtual ICollection<SideMenu> SideMenus { get; set; }

        //public virtual ICollection<Role> Roles { get; set; }
    }
}
