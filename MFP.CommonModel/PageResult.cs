using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.CommonModel
{
    public class PageResult<T>
    {
        public int code { get; set; }

        public string msg { get; set; }

        public int count { get; set; }

        public T data{ get; set;}
    }

    public class PageResult
    {
        public int code { get; set; }

        public string msg { get; set; }

        public int count { get; set; }

        public object data { get; set; }
    }
}
