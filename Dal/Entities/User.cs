namespace Dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string UserID { get; set; }

        [Column(TypeName = "varchar")]
        [Required,StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Pwd { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
