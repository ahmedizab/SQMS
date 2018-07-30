using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

using System.Collections.Generic;

using System.Drawing.Imaging;

using System.Text;
using Microsoft.Reporting.WebForms;

public class TokenPrint
{
    private int m_currentPageIndex;
    private IList<Stream> m_streams;

    private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
    {
        Stream stream = new MemoryStream();
        m_streams.Add(stream);
        return stream;
    }

    public void Export(LocalReport report)
    {
        string deviceInfo =
          @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
        Warning[] warnings;
        m_streams = new List<Stream>();

        report.Render("Image", deviceInfo, CreateStream, out warnings);
        foreach (Stream stream in m_streams)
            stream.Position = 0;
    }

    public void PosExport(LocalReport report)
    {
        string deviceInfo =
          @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3.00in</PageWidth>
                <PageHeight>9.00in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
        Warning[] warnings;
        m_streams = new List<Stream>();

        report.Render("Image", deviceInfo, CreateStream, out warnings);
        foreach (Stream stream in m_streams)
            stream.Position = 0;
    }
    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
        Metafile pageImage = new
           Metafile(m_streams[m_currentPageIndex]);

        System.Drawing.Rectangle adjustedRect = new System.Drawing.Rectangle(
            ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
            ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
            ev.PageBounds.Width,
            ev.PageBounds.Height);

        ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
        ev.Graphics.DrawImage(pageImage, adjustedRect);
        m_currentPageIndex++;
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
    }

    public void Print()
    {
        if (m_streams == null || m_streams.Count == 0)
            throw new Exception("Error: no stream to print.");
        PrintDocument printDoc = new PrintDocument();
        if (!printDoc.PrinterSettings.IsValid)
        {
            throw new Exception("Error: cannot find the default printer.");
        }
        else
        {
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            m_currentPageIndex = 0;
            printDoc.Print();
        }
    }

    public void Dispose()
    {
        if (m_streams != null)
        {
            foreach (Stream stream in m_streams)
                stream.Close();
            m_streams = null;
        }

    }

}