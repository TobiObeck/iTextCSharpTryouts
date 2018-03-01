using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace iTextSharpTryOut1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDocument();
            //SetPageSize();
            CreatFromTemplate();
        }

        public static void CreatFromTemplate()
        {
            string originalFile = "Original.pdf";
            string copyOfOriginal = "Copy.pdf";
            using (FileStream fs = new FileStream(originalFile, FileMode.Create, FileAccess.Write, FileShare.None))
            using (Document doc = new Document(PageSize.LETTER))
            using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
            {
                doc.Open();
                doc.Add(new Paragraph("Hi! I'm Original"));
                doc.Close(); 
            }
            PdfReader reader = new PdfReader(originalFile);
            using (FileStream fs = new FileStream(copyOfOriginal, FileMode.Create, FileAccess.Write, FileShare.None))
            // Creating iTextSharp.text.pdf.PdfStamper object to write
            // Data from iTextSharp.text.pdf.PdfReader object to FileStream object
            
            using (PdfStamper stamper = new PdfStamper(reader, fs)) {
                // Getting total number of pages of the Existing Document
                int pageCount = reader.NumberOfPages;

                // Create New Layer for Watermark
                PdfLayer layer = new PdfLayer("WatermarkLayer", stamper.Writer);
                // Loop through each Page
                for (int i = 1; i <= pageCount; i++)
                {
                    // Getting the Page Size
                    Rectangle rect = reader.GetPageSize(i);

                    // Get the ContentByte object
                    PdfContentByte cb = stamper.GetUnderContent(i);

                    // Tell the cb that the next commands should be "bound" to this new layer
                    cb.BeginLayer(layer);
                    cb.SetFontAndSize(BaseFont.CreateFont(
                      BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 50);

                    PdfGState gState = new PdfGState();
                    gState.FillOpacity = 0.25f;
                    cb.SetGState(gState);

                    cb.SetColorFill(BaseColor.BLACK);
                    cb.BeginText();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "OK COOL A WATERMARK", rect.Width / 2, rect.Height / 2, 45f);
                    cb.EndText();

                    // Close the layer
                    cb.EndLayer();
                }
            }
        }
        
        public static void CreateDocument()
        {


            // create filestream object
            FileStream fs = new FileStream("Example.pdf", FileMode.Create);

            // create document object
            Document doc = new Document();

            // create PdfWriter instance which will write at file filestream
            PdfWriter.GetInstance(doc, fs);

            // opening the dociment
            doc.Open();

            // creating paragraph object
            Paragraph para = new Paragraph("ERSTE PDF BROT Welcome to asparticles.com. This is first paragraph.");

            // adding pargraph to document
            doc.Add(para);

            // closing the document
            doc.Close();
        } 
        

        public static void SetPageSize()
        {

            FileStream fs = new FileStream("Example2.pdf", FileMode.Create);

            // setting page page size and background color
            Rectangle rec = new Rectangle(PageSize.A4);
            rec.BackgroundColor = new BaseColor(200,200,200,128);

            //OR
            //Rectangle rec2 = new Rectangle(70, 720); // for page size
            //rec2.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);

            Document doc = new Document(rec);

            PdfWriter.GetInstance(doc, fs);

            doc.Open();

            //Paragraph para = new Paragraph("2.PDF Welcome to asparticles.com. Pdf with pagesize A4. Different kind of pagesize is supported");
            Paragraph para = new Paragraph("Hallo ihr dummen Mistgeburten! Ich möchte Euch sagen, dass ich euch lieb habe. HDL");

            doc.Add(para);

            doc.Close();
        }
    }
}
