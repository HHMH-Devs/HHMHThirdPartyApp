using Microsoft.Reporting.WinForms;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;

namespace ThirdPartyAppV2.Common.Modules.Reports
{
    [Log]
    public static partial class Modul_Print_Reports
    {
        private static int m_currentPageIndex;
        private static IList<Stream> m_streams;
        private static PrintDocument printdoc;

        /// <summary>
        /// Print rdlc report with custom page width and height
        /// </summary>
        /// <param name="report"></param>
        /// <param name="page_width">the width of the papger, in hunderdths of an inch</param>
        /// <param name="page_height">the height of the papger, in hunderdths of an inch</param>
        /// <param name="islandscap"></param>
        /// <param name="printer_name">Ignore this parameter to use default printer</param>
        /// <remarks></remarks>
        public static void Print_microsoft_report(ref LocalReport report, int page_width, int page_height, bool islandscap = false, string printer_name = null)

        {
            printdoc = new PrintDocument();
            if (!string.IsNullOrEmpty(printer_name))
                printdoc.PrinterSettings.PrinterName = printer_name;
            if (!printdoc.PrinterSettings.IsValid) // detecate is the printer is exist
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                var ps = new PaperSize("Custom", page_width, page_height);
                printdoc.DefaultPageSettings.PaperSize = ps;
                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                Print();
            }
        }
        /// <summary>
        /// Print rdlc report with specific paper kind
        /// </summary>
        /// <param name="report"></param>
        /// <param name="paperkind">String paper Kind, ex:"letter"</param>
        /// <param name="islandscap"></param>
        /// <param name="printer_name">Ignore this parameter to use default printer</param>
        /// <remarks></remarks>
        public static void Print_microsoft_report(LocalReport report, string paperkind = "Custom1", bool islandscap = false, string printer_name = null)

        {

            printdoc = new PrintDocument();
            if (!string.IsNullOrEmpty(printer_name))
                printdoc.PrinterSettings.PrinterName = printer_name;
            if (!printdoc.PrinterSettings.IsValid) // detecate is the printer is exist
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                PaperSize ps;
                bool pagekind_found = false;
                for (int i = 0, loopTo = printdoc.PrinterSettings.PaperSizes.Count - 1; i <= loopTo; i++)
                {
                    if (printdoc.PrinterSettings.PaperSizes[i].Kind.ToString() == paperkind)
                    {
                        ps = printdoc.PrinterSettings.PaperSizes[i];
                        printdoc.DefaultPageSettings.PaperSize = ps;
                        pagekind_found = true;
                    }
                }
                if (!pagekind_found)
                    throw new Exception("paper size is invalid");
                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                Print();
            }

        }

        // Routine to provide to the report renderer, in order to
        // save an image for each page of the report.
        private static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private static void Export(LocalReport report)
        {
            int w;
            int h;
            if (printdoc.DefaultPageSettings.Landscape == true)
            {
                w = printdoc.DefaultPageSettings.PaperSize.Height;
                h = printdoc.DefaultPageSettings.PaperSize.Width;
            }
            else
            {
                w = printdoc.DefaultPageSettings.PaperSize.Width;
                h = printdoc.DefaultPageSettings.PaperSize.Height;
            }
            string deviceInfo = "<DeviceInfo>\r\n" +
                "<OutputFormat>EMF</OutputFormat>\r\n" +
                "<PageWidth>8.5in</PageWidth>\r\n" +
                "<PageHeight>13in</PageHeight>\r\n" +
                "<MarginTop>0.0in</MarginTop>\r\n" +
                "<MarginLeft>0.0in</MarginLeft>\r\n" +
                "<MarginRight>0.0in</MarginRight>\r\n" +
                "<MarginBottom>0.0in</MarginBottom>\r\n" +
                "</DeviceInfo>";

            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out Warning[] warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0L;
        }

        // Handler for PrintPageEvents
        private static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            var pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            var adjustedRect = new Rectangle(Convert.ToInt32(ev.PageBounds.Left - ev.PageSettings.HardMarginX), Convert.ToInt32(ev.PageBounds.Top - ev.PageSettings.HardMarginY), ev.PageBounds.Width, ev.PageBounds.Height);


            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex += 1;
            ev.HasMorePages = m_currentPageIndex < m_streams.Count;
        }
        private static void Print()
        {
            if (m_streams is null || m_streams.Count == 0)
            {
                throw new Exception("Error: no stream to print.");
            }
            printdoc.PrintPage += PrintPage;
            m_currentPageIndex = 0;
            printdoc.Print();
        }
    }
}
