using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;

namespace WebUI.Controllers
{
    public class HttpRequestController : Controller
    {
        // GET: HttpClient
        public ActionResult HttpClientDemo()
        {
            HttpClient client = new HttpClient();
            var url = "http://xurongjian:20017/api/Test";

            var postData = new Dictionary<string, string>
            {
                { "username", "test" },
                { "words", "hello world" }
            };

            var urlEncodedContent = new FormUrlEncodedContent(postData);
            var result=client.PostAsync(url, urlEncodedContent).Result.Content.ReadAsStringAsync().Result;
 
            ViewData["Reuslt"] = result;

            return View();
        }

        public ActionResult HttpWebRequestDemo()
        {
            HttpWebRequest request= WebRequest.Create("http://xurongjian:20017/api/Test?t=xml") as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            string param = "username=test&words=hello world";
            byte[] param_bytes = Encoding.UTF8.GetBytes(param);
            //request.ContentType = "application/json;charset=utf-8";
            //byte[] param_bytes = Encoding.UTF8.GetBytes("{\"username\":\"test\",\"words\":\"hello world\"}");
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(param_bytes,0,param_bytes.Length);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    ViewData["Reuslt"] = reader.ReadToEnd();
                }
            }
            return View();
        }
    }
}