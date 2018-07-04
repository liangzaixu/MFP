using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.MvcExtension
{
    public class ErrorInfo
    {
        public ErrorInfo()
        {
            Title = "错误。";
            Msg = "处理你的请求时出错。";
        }

        public string Title { get; set; }
        public string Msg { get; set; }
    }
}
