using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText;

using System.Text;
using iText.Kernel.Geom;

namespace iTextSharpTryOutBase64
{
    /// <summary>Simple Hello World example.</summary>
    public class C01E01_HelloWorld
    {
        public const String DEST = "results/chapter01/hello_world.pdf";
        public const String DESTYOLO = "results/chapter01/raw.pdf";
        public const String DEST3 = "results/chapter01/someOUTPUT.pdf";


        /// <exception cref="System.IO.IOException"/>
        public static void Main(String[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();
            new C01E01_HelloWorld().CreatePdf(DEST);


            Console.ReadLine();
        }

        /// <exception cref="System.IO.IOException"/>
        public virtual void CreatePdf(String dest)
        {
            /*
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(dest);
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
            Document document = new Document(pdf);
            //Add paragraph to the document
            document.Add(new Paragraph("helloooo!"));
            //Close document
            document.Close();
            */

            string base64string = "";
            
            // Open the stream and read it back.
            using (FileStream fs = File.Open(DESTYOLO, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    //Console.WriteLine(temp.GetString(b));
                    base64string += temp.GetString(b);
                }
            }

            byte[] input = Convert.FromBase64String(base64string);

            //var fs2 = new FileStream(DESTYOLO, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var fs2 = new MemoryStream(input);
            //using (var sr = new StreamReader(fs))
            //{
            // Console.WriteLine("" + sr.ReadToEnd());

            //using (MemoryStream myoutPDF = new MemoryStream())
            //{
            using (PdfReader pdfreader = new PdfReader(fs2))
            {
                using (PdfWriter pdfwriter = new PdfWriter(DEST3))
                {

                    using (PdfDocument pdfdoc = new PdfDocument(pdfreader, pdfwriter))
                    {
                        using (Document doc = new Document(pdfdoc))
                        {
                            doc.Add(new Paragraph("hi ho boyz!"));
                            doc.Add(new Paragraph("hi ho boyz!"));
                            doc.Add(new Paragraph("hi ho boyz!"));
                            doc.Add(new Paragraph("hi ho boyz!"));

                            doc.Close();
                        }
                    }

                    //return myoutPDF.ToArray();
                }
            }
            //}

            //}

            /*
            using (MemoryStream outPDF = new MemoryStream())
            {
                using (PdfReader pdfr = new PdfReader(inPDF))
                {
                    using (Document doc = new Document(PageSize.LETTER))
                    {
                        //...
                    }
                }

                Console.WriteLine("OKcool" +  outPDF.ToArray();
            }
            */
        }
    }


}
