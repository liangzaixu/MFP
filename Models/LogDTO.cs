using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LogDTO
    {

        public int ID { get; set; }
        public string UserID { get; set; }
        public string IP { get; set; }
        public DateTime OperateTime { get; set; }
    }
}
