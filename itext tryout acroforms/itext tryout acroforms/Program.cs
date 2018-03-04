/*
* This example is part of the iText 7 tutorial.
*/
using System;
using System.IO;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Tutorial.Chapter04
{
    /// <summary>Simple widget annotation example.</summary>
    public class C04E02_JobApplication
    {
        public const String DEST = "results/chapter04/job_application.pdf";

        /// <exception cref="System.IO.IOException"/>
        public static void Main(String[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();
            new C04E02_JobApplication().CreatePdf(DEST);
        }

        /// <exception cref="System.IO.IOException"/>
        public virtual void CreatePdf(String dest)
        {
            PdfDocument pdf = new PdfDocument(new PdfWriter(dest));            
            pdf.SetDefaultPageSize(PageSize.A4);
            Document doc = new Document(pdf);

            Paragraph title = new Paragraph("Application for employment").SetTextAlignment(TextAlignment.CENTER).SetFontSize(16);
            doc.Add(title);

            PdfAcroForm form = PdfAcroForm.GetAcroForm(doc.GetPdfDocument(), true);            
            PdfTextFormField nameField = PdfTextFormField.CreateText(doc.GetPdfDocument(), new Rectangle(99, 753, 425, 15), "name", "");
            nameField.SetRequired(true);
            form.AddField(nameField);

            doc.Close();
        }
    }
}