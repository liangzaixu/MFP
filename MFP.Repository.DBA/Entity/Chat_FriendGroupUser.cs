using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFP.Repository.Entities.Entity
{
    public class Chat_FriendGroupUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int FriendGroupId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string UserId { get; set; }

    }
}
