using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal
{
    [Table("Province")]
    public class Province
    {
        public int ProvinceID { get; set; }

        public string ProvinceName { get; set; }

        public virtual ICollection<City> Citys { get; set; }



    }
}
