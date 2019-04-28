using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFP.Repository.Entities.Entity
{
    public class Chat_Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar"), Required]
        [StringLength(50)]
        public string OwnerId { get; set; }

        [Column(TypeName = "nvarchar"),Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(300)]
        public string Photo { get; set; }

        [Required]
        public string OrderNo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
