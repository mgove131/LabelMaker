using LabelMaker.Model.ExtensionMethods;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.Diagnostics;

namespace LabelMaker.ViewModel
{
    public static class PdfMaker
    {
        public static void PrintLabels(string filePath, int numLabels, List<string> proNums, int startingLabelIndex)
        {
            filePath.SafeDelete();

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);

            int[] xOffSets = { 40, 310 };
            int yOffset = 100;
            int ySpacing = 60;
            int width = 250;
            int height = 44;
            for (int i = 0; i < numLabels; i++)
            {
                int x = xOffSets[i % xOffSets.Length];
                int y = yOffset + (ySpacing * (i / xOffSets.Length));
                string text = string.Empty;

                if (startingLabelIndex <= i)
                {
                    int proNumIndex = i - startingLabelIndex;
                    string proNum = (proNumIndex < proNums.Count) ? proNums[proNumIndex] : string.Empty;
                    text = string.Format("Pro #: {0}", proNum);
                }

                XRect rect = new XRect(x, y, width, height);
                gfx.DrawRectangle(XBrushes.SeaShell, rect);
                tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            }

            //save pdf
            document.Save(filePath);
            //open pdf
            Process.Start(filePath);
        }
    }
}
