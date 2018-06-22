using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.CommonModel
{
    public class PageResult<T>
    {
        public int Status { get; set; }

        public string Msg { get; set; }

        public int Total { get; set; }

        public T Data{ get; set;}
    }

    public class PageResult
    {
        public int Status { get; set; }

        public string Msg { get; set; }

        public int Total { get; set; }

        public object Data { get; set; }
    }
}
