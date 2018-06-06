using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Repository.DBA.Entity
{
    [Table("SideMenu")]
    public class SideMenu
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string MenuID { get; set; }
    
        [Column(TypeName="nvarchar")]
        [Required,StringLength(30)]
        public string MenuName { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(200)]
        public string Url { get; set; }

        public string HeaderMenuID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string ParentID { get; set; }

        [Required]
        public int MenuOrder { get; set; }

        [ForeignKey("HeaderMenuID")]
        public HeaderMenu HeaderMenu { get; set; }

        public virtual ICollection<DetailAction> DetailActions { get; set; }

        //public virtual ICollection<Role> Roles { get; set; }

    }
}
