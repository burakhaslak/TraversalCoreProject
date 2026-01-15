using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "doc1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Reservation Pdf Report");
            document.Add(paragraph);
            document.Close();

            return File("/pdfreports/doc1.pdf", "application/pdf", "doc1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "doc2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfTable = new PdfPTable(3);
            pdfTable.AddCell("Guest's Name");
            pdfTable.AddCell("Guest's Surname");
            pdfTable.AddCell("Guest's Identity");

            pdfTable.AddCell("Santino");
            pdfTable.AddCell("Carter");
            pdfTable.AddCell("12365498754");

            pdfTable.AddCell("Rayne");
            pdfTable.AddCell("Parrish");
            pdfTable.AddCell("78549632156");

            pdfTable.AddCell("Gianna");
            pdfTable.AddCell("Murray");
            pdfTable.AddCell("65984623156");

            document.Add(pdfTable);

            document.Close();

            return File("/pdfreports/doc2.pdf", "application/pdf", "doc2.pdf");
        }
    }
}
