using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFP.Repository.Entities.Entity
{
    /// <summary>
    /// 一对一的外键关系
    /// </summary>
    [Table("IDCard")]
    public class IDCard
    {
        [Key,ForeignKey("Person")]
        public int PersonID { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual Person Person { get; set; }
    }
}
