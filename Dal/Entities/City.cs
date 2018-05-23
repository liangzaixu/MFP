using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entities
{
    [Table("City")]
    public class City
    {
        
        public int CityID { get; set; }

        public string CiryName { get; set; }

        [Required]//添加Required构成级联删除
        public int ProvinceID { get; set; }

        [ForeignKey("ProvinceID")]//指定外键名
        public Province Province { get; set; }
    }
}
