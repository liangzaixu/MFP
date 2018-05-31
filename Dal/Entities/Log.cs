namespace Dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("UserID",TypeName="varchar")]
        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(30)]
        public string IP { get; set; }

        public DateTime? OperateTime { get; set; }
    }
}
