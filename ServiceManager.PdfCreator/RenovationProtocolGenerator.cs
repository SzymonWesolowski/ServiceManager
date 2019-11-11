using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ServiceManager.Application;
using ServiceManager.Domain.Model;

namespace ServiceManager.PdfCreator
{
    public class RenovationProtocolGenerator : IRenovationProtocolGenerator
    {
        public void Generate(RenovationProtocol protocol)
        {
            PdfWriter writer = new PdfWriter("./renovation.pdf");
            PdfDocument pdfDocument = new PdfDocument(writer);
            Document document = new Document(pdfDocument);
            PdfFont font = PdfFontFactory.CreateFont(@"C:\Fonts\arial.ttf", "cp1250", true);
            Text text = new Text("Renovation Protocol" + protocol.Estate.City + ", " + protocol.Estate.Street ).SetFont(font);
            document.Add(new Paragraph().Add(text));
            document.Close();
        }
    }
}