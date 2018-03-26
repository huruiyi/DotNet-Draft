using Codaxy.WkHtmlToPdf;

namespace HtmlToPdf
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PdfConvert.ConvertHtmlToPdf(new PdfDocument
            {
                Url = @"layout.html"
            }, new PdfOutput
            {
                OutputFilePath = "layout.pdf"
            });
        }
    }
}