using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFP.Repository.Entities.Entity
{
    [Table("DetailAction")]
    public class DetailAction
    {
        [Key]
        [Column("ActionID", TypeName = "varchar")]
        [StringLength(30)]
        public string ActionID { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required,StringLength(30)]
        public string ActionName { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string Description { get; set; }

        public string SideMenuID { get; set; }

        [ForeignKey("SideMenuID")]
        public SideMenu SideMenu { get; set; }

        //public virtual ICollection<Role> Roles { get; set; }
    }
}
