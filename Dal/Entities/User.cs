namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [StringLength(30)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Age { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Pwd { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
