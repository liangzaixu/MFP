using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFP.WebUI.Controllers
{
    public class FilePreviewController : Controller
    {
        // GET: FilePreview
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OfficeFile()
        {
            return View();
        }

        public JsonResult ConvertToPdf(string filePath)
        {

            return Json("");
        }

        public ActionResult TxtFile()
        {
            return View();
        }

        public ActionResult VideoFile()
        {
            return View();
        }

        public ActionResult AudioFile()
        {
            return View();
        }

        public ActionResult PDF()
        {
            return View();
        }
    }
}