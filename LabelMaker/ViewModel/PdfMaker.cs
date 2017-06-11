using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace LabelMaker.ViewModel
{
    public static class PdfMaker
    {
        public static void PrintLabels(string filePath, List<string> proNums, int startingLabelIndex)
        {
            //delete old pdf
            try
            {
                File.Delete(filePath);
            }
            catch { }

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
              new XRect(0, 0, page.Width, page.Height),
              XStringFormats.Center);

            //save pdf
            document.Save(filePath);
            //open pdf
            Process.Start(filePath);
        }
    }
}
