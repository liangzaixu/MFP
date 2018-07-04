using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MFP.Service.BGSystem;

namespace MFP.WebUI.Controllers
{
    public class AsyncController : Controller
    {
        private UserService _userService = new UserService();

        public ActionResult Index()
        {
            // Task.Run()、Task.Factory.StartNew()、new Thread().Start()会立即开启新的线程

            //var task1 = Task.Factory.StartNew(() => _userService.AtAsyncHttpContextCurrentIsNull());
            var task1 = Task.Run(() => _userService.AtAsyncHttpContextCurrentIsNull());
            //挂起主线程，等待结果
            bool isNull = task1.GetAwaiter().GetResult();

            //此处不会会挂起主线程
            DoSomething();

            return View();
        }

        public async Task DoSomething()
        {
            // await 从来不会开启新的线程，而是遇到.net内部Async方法时才会开启线程、或自己创建Task
            string name = await GetName();
        }

        public async Task<string> GetName()
        {
            await Task.Delay(3000);
            return "Aries";
        }
    }
}