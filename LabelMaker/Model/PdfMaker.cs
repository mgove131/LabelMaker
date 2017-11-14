using LabelMaker.Model.ExtensionMethods;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LabelMaker.ViewModel
{
    /// <summary>
    /// Prints the PDF output.
    /// </summary>
    public static class PdfMaker
    {
        /// <summary>
        /// Print the pdf output.
        /// </summary>
        /// <param name="filePath">Output file path</param>
        /// <param name="outputObjects">Objects to print</param>
        /// <param name="openPdf">Should the pdf file be opened?</param>
        public static void PrintLabels(string filePath, List<OutputObject> outputObjects, bool openPdf)
        {
            filePath.SafeFileDelete();

            PdfDocument pdfDocument = new PdfDocument();
            XGraphics gfx = XGraphics.FromPdfPage(pdfDocument.AddPage());
            XFont font = new XFont("Times New Roman", 10.0, XFontStyle.Regular);
            XTextFormatter xtextFormatter = new XTextFormatter(gfx);
            XBrush brush = false ? (XBrush)XBrushes.DarkGray : (XBrush)XBrushes.Transparent;

            int[] xOffsets = new int[] { 40, 345 };
            int yOffset = 59;
            int yIncrement = 143;
            int width = 245;
            int height = 115;
            for (int i = 0; i < outputObjects.Count; i++)
            {
                OutputObject outputObject = outputObjects[i];
                if (!outputObject.IsEmpty())
                {
                    int x = xOffsets[i % xOffsets.Length];
                    int y = yOffset + (yIncrement * (i / xOffsets.Length));

                    string date = outputObject.Date;
                    string proNumber = outputObject.ProNumber;
                    string customer = outputObject.Customer;
                    string driver = outputObject.Driver;
                    string notes = outputObject.Notes;

                    string text = string.Empty;
                    text += string.Format("   Pro #: {0}{1}{1}", proNumber, Environment.NewLine);
                    text += string.Format("   Date: {0:d}{1}{1}", date, Environment.NewLine);
                    text += string.Format("   Customer: {0}{1}{1}", customer, Environment.NewLine);
                    text += string.Format("   Driver: {0}{1}{1}", driver, Environment.NewLine);
                    text += string.Format("   Notes: {0}", notes, Environment.NewLine);

                    XRect xrect = new XRect((double)x, (double)y, (double)width, (double)height);
                    gfx.DrawRectangle(brush, xrect);
                    xtextFormatter.DrawString(text, font, (XBrush)XBrushes.Black, xrect, XStringFormats.TopLeft);
                }
            }

            pdfDocument.Save(filePath);
            if (!openPdf) return;
            Process.Start(filePath);
        }
    }
}
