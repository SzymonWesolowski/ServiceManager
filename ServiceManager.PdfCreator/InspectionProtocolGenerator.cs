using System;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ServiceManager.Application;
using ServiceManager.Domain;
using ServiceManager.Domain.Model;

namespace ServiceManager.PdfCreator
{
    public class InspectionProtocolGenerator : IInspectionProtocolGenerator
    {
        public void Generate(InspectionProtocol protocol)
        {
            PdfWriter writer = new PdfWriter("./inspection.pdf");
            PdfDocument pdfDocument = new PdfDocument(writer);
            Document document = new Document(pdfDocument);
            PdfFont font = PdfFontFactory.CreateFont(@"C:\Fonts\arial.ttf", "cp1250", true);
            Text text = new Text("Inspection Protocol" + protocol.Estate.City + ", " + protocol.Estate.Street).SetFont(font);
            document.Add(new Paragraph().Add(text));
            document.Close();
        }
    }
}