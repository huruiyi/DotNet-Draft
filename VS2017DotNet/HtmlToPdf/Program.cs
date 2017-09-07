using Codaxy.WkHtmlToPdf;

namespace HtmlToPdf
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PdfConvert.ConvertHtmlToPdf(new PdfDocument
            {
                Url = "http://www.sina.com/"
            }, new PdfOutput
            {
                OutputFilePath = "sina.pdf"
            });
        }
    }
}