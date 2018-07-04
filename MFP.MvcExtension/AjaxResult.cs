using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.MvcExtension
{
    public class AjaxResult
    {
        public AjaxResult(int status, string msg, object data)
        {
            Status = status;
            Msg = msg;
            Data = data;
        }

        public AjaxResult(int status, string msg) : this(status, msg, null)
        {
        }

        public AjaxResult(int status) : this(status, string.Empty, null)
        {
        }

        public AjaxResult() : this(200, string.Empty, null)
        {
        }

        public int Status { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }

    public class AjaxResult<T>
    {
        public AjaxResult(int status, string msg, T data)
        {
            Status = status;
            Msg = msg;
            Data = data;
        }

        public AjaxResult(int status, string msg) : this(status, msg, default(T))
        {
        }

        public AjaxResult(int status) : this(status, string.Empty, default(T))
        {
        }

        public AjaxResult() : this(200, "success", default(T))
        {
        }

        public int Status { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
    }
}
