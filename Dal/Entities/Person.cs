using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal
{
    /// <summary>
    /// 一对一的外键关系
    /// </summary>
    [Table("Person")]
    public class Person
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual IDCard Idcard { get; set; }

        public virtual ICollection<Lodging> PrimaryContactFor { get; set; }

        public virtual ICollection<Lodging> SecondaryContactFor { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        [ConcurrencyCheck]
        public int SocialScurityNumber { get; set; }
    }
}
