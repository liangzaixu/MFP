using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.PowerPoint;

namespace MFP.Utility
{
    /// <summary>
    /// Office文档转换为PDF
    /// </summary>
    public class OfficeConvertPdf
    {
        /// <summary>
        /// 将word文档转换成PDF格式
        /// </summary>
        /// <param name="sourcePath">源文件绝对路径</param>
        /// <param name="targetPath">目标文件绝对路径</param>
        /// <param name="exportFormat">导出格式</param>
        /// <returns>是否转换成功</returns>
        public static bool WordConvertPdf(string sourcePath, string targetPath, Microsoft.Office.Interop.Word.WdExportFormat exportFormat = Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF)
        {
            bool result;
            object paramMissing = Type.Missing;
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document wordDocument = null;
            try
            {
                object paramSourceDocPath = sourcePath;
                string paramExportFilePath = targetPath;

                Microsoft.Office.Interop.Word.WdExportFormat paramExportFormat = exportFormat;
                bool paramOpenAfterExport = false;
                Microsoft.Office.Interop.Word.WdExportOptimizeFor paramExportOptimizeFor =
                        Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
                Microsoft.Office.Interop.Word.WdExportRange paramExportRange = Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument;
                int paramStartPage = 0;
                int paramEndPage = 0;
                Microsoft.Office.Interop.Word.WdExportItem paramExportItem = Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent;
                bool paramIncludeDocProps = true;
                bool paramKeepIRM = true;
                Microsoft.Office.Interop.Word.WdExportCreateBookmarks paramCreateBookmarks =
                        Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
                bool paramDocStructureTags = true;
                bool paramBitmapMissingFonts = true;
                bool paramUseISO19005_1 = false;

                wordDocument = wordApplication.Documents.Open(
                        ref paramSourceDocPath, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing);

                if (wordDocument != null)
                    wordDocument.ExportAsFixedFormat(paramExportFilePath,
                            paramExportFormat, paramOpenAfterExport,
                            paramExportOptimizeFor, paramExportRange, paramStartPage,
                            paramEndPage, paramExportItem, paramIncludeDocProps,
                            paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                            paramBitmapMissingFonts, paramUseISO19005_1,
                            ref paramMissing);
                result = true;
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordApplication = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }

        /// <summary>
        /// 将excel文档转换成PDF格式
        /// </summary>
        /// <param name="sourcePath">源文件绝对路径</param>
        /// <param name="targetPath">目标文件绝对路径</param>
        /// <param name="targetType">导出格式</param>
        /// <returns>是否转换成功</returns>
        public static bool ExcelConvertPdf(string sourcePath, string targetPath, XlFixedFormatType targetType = XlFixedFormatType.xlTypePDF)
        {
            bool result;
            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.Application application = null;
            Workbook workBook = null;
            try
            {
                application = new Microsoft.Office.Interop.Excel.Application();
                object target = targetPath;
                object type = targetType;
                workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing, missing, missing);

                workBook.ExportAsFixedFormat(targetType, target, XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }

        /// <summary>
        /// 将ppt文档转换成PDF格式
        /// </summary>
        /// <param name="sourcePath">源文件绝对路径</param>
        /// <param name="targetPath">目标文件绝对路径</param>
        /// <param name="targetFileType">导出格式</param>
        /// <returns>是否转换成功</returns>
        public static bool PptConvertPdf(string sourcePath, string targetPath, PpSaveAsFileType targetFileType = PpSaveAsFileType.ppSaveAsPDF)
        {
            bool result;
            object missing = Type.Missing;
            Microsoft.Office.Interop.PowerPoint.Application application = new Microsoft.Office.Interop.PowerPoint.Application();
            Presentation persentation = null;
            try
            {
                persentation = application.Presentations.Open(sourcePath, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                persentation.SaveAs(targetPath, targetFileType, Microsoft.Office.Core.MsoTriState.msoTrue);

                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (persentation != null)
                {
                    persentation.Close();
                    persentation = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }

    }

}
