using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Aspose.BarCode;
using Aspose.BarCodeRecognition;
using Aspose;
using Aspose.Cells;
using Aspose.Slides;
using Aspose.Words;

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
        
        [HttpPost]
        public JsonResult ConvertToPdf(string fileType)
        {
            string pdfName=string.Empty;
            string source=string.Empty;
            string destination = string.Empty;
            switch (fileType)
            {
                case "word":
                    source = Server.MapPath(@"~/File/中高考英语自适应学习训练平台-正式版 用户角色身份说明.docx");
                    pdfName= $"{GetMD5HashFromFile(source)}.pdf";
                    destination= Server.MapPath($"~/File/{pdfName}");
                    if (!System.IO.File.Exists(destination))
                    {
                        Document doc = new Document(source);
                        doc.Save(destination, Aspose.Words.SaveFormat.Pdf);
                    }

                    break;
                case "excel":
                    source = Server.MapPath(@"~/File/租房提取申请.xls");
                    pdfName = $"{GetMD5HashFromFile(source)}.pdf";
                    destination = Server.MapPath($"~/File/{pdfName}");
                    if (!System.IO.File.Exists(destination))
                    {
                        Workbook excel = new Workbook(source);
                        excel.Save(destination, Aspose.Cells.SaveFormat.Pdf);
                    }

                    break;
                case "ppt":
                    source = Server.MapPath(@"~/File/3、事务与锁.ppt");
                    pdfName = $"{GetMD5HashFromFile(source)}.pdf";
                    destination = Server.MapPath($"~/File/{pdfName}");
                    if (!System.IO.File.Exists(destination))
                    {
                        Presentation ppt = new Presentation(source);
                        ppt.Save(destination, Aspose.Slides.Export.SaveFormat.Pdf);
                    }

                    break;
            }
            return Json(new {fileName=pdfName });
        }

        private string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
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