using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ServiceManager.Application;
using ServiceManager.Domain.Model;

namespace ServiceManager.PdfCreator
{
    public class RepairProtocolGenerator : IRepairProtocolGenerator
    {
        public void Generate(RepairProtocol protocol)
        {
            PdfWriter writer = new PdfWriter("./repair.pdf");
            PdfDocument pdfDocument = new PdfDocument(writer);
            Document document = new Document(pdfDocument);
            PdfFont font = PdfFontFactory.CreateFont(@"C:\Fonts\arial.ttf", "cp1250", true);
            Text text = new Text("Repair Protocol" + protocol.City + ", " + protocol.Address).SetFont(font);
            document.Add(new Paragraph().Add(text));
            document.Close();
        }
    }
}