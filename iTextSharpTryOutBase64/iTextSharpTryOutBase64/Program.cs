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

        public const String DEST_INPUT = "results/chapter01/raw.txt";
        public const String DEST_OUT = "results/chapter01/someOUTPUT2.pdf";

        /// <exception cref="System.IO.IOException"/>
        public static void Main(String[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            //new C01E01_HelloWorld().CreatePdf(DEST);
            new C01E01_HelloWorld().readBase64StringOutputAsPDF();

            Console.ReadLine();
        }
        public virtual void CreatePdf(String dest)
        {
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(dest);

            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);

            // Initialize document
            Document document = new Document(pdf);

            //Add paragraph to the document
            document.Add(new Paragraph("HALLO DUDE!"));

            //Close document
            document.Close();
        }

        /// <exception cref="System.IO.IOException"/>
        public virtual void readBase64StringOutputAsPDF()
        {
            string inputStr = "";

            // Open the stream and read it back.
            using (FileStream fs = File.Open(DEST_INPUT, FileMode.Open))
            {
                byte[] tempBuffer = new byte[1024];
                UTF8Encoding utf8Encoding = new UTF8Encoding(true);
                Encoding ansiEncoding = Encoding.Default;

                while (fs.Read(tempBuffer, 0, tempBuffer.Length) > 0)
                {
                    inputStr += utf8Encoding.GetString(tempBuffer);
                    //inputStr += ansiEncoding.GetString(tempBuffer);
                }
            }
            //inputStr = "JVBERi0xLjcKJeLjz9MKNSAwIG9iago8PC9GaWx0ZXIvRmxhdGVEZWNvZGUvTGVuZ3RoIDYxPj5zdHJlYW0KeJwr5HIK4dJ3M1QwNFIISeMyNlMwt7DUMzZWCEnh0vBIzcnJVwjPL8pJUUwsTtEMyeJyDeEK5AIAUb4NXAplbmRzdHJlYW0KZW5kb2JqCjQgMCBvYmoKPDwvQ29udGVudHMgNSAwIFIvTWVkaWFCb3hbMCAwIDU5NSA4NDJdL1BhcmVudCAyIDAgUi9SZXNvdXJjZXM8PC9Gb250PDwvRjEgNiAwIFI+Pj4+L1RyaW1Cb3hbMCAwIDU5NSA4NDJdL1R5cGUvUGFnZT4+CmVuZG9iagoxIDAgb2JqCjw8L1BhZ2VzIDIgMCBSL1R5cGUvQ2F0YWxvZz4+CmVuZG9iagozIDAgb2JqCjw8L0NyZWF0aW9uRGF0ZShEOjIwMTgwMzAxMTYwNTM5KzAxJzAwJykvTW9kRGF0ZShEOjIwMTgwMzAxMTYwNTM5KzAxJzAwJykvUHJvZHVjZXIoaVRleHSuIDcuMS4xIKkyMDAwLTIwMTggaVRleHQgR3JvdXAgTlYgXChBR1BMLXZlcnNpb25cKSk+PgplbmRvYmoKNiAwIG9iago8PC9CYXNlRm9udC9IZWx2ZXRpY2EvRW5jb2RpbmcvV2luQW5zaUVuY29kaW5nL1N1YnR5cGUvVHlwZTEvVHlwZS9Gb250Pj4KZW5kb2JqCjIgMCBvYmoKPDwvQ291bnQgMS9LaWRzWzQgMCBSXS9UeXBlL1BhZ2VzPj4KZW5kb2JqCnhyZWYKMCA3CjAwMDAwMDAwMDAgNjU1MzUgZiAKMDAwMDAwMDI3NSAwMDAwMCBuIAowMDAwMDAwNTY1IDAwMDAwIG4gCjAwMDAwMDAzMjAgMDAwMDAgbiAKMDAwMDAwMDE0MiAwMDAwMCBuIAowMDAwMDAwMDE1IDAwMDAwIG4gCjAwMDAwMDA0NzcgMDAwMDAgbiAKdHJhaWxlcgo8PC9JRCBbPDUzOWYxYjUyZThjNjlmOTQzNzIyYjczMTFhMTFkMmNkPjw1MzlmMWI1MmU4YzY5Zjk0MzcyMmI3MzExYTExZDJjZD5dL0luZm8gMyAwIFIvUm9vdCAxIDAgUi9TaXplIDc+PgolaVRleHQtNy4xLjEgZm9yIC5ORVQKc3RhcnR4cmVmCjYxNgolJUVPRgo=";

            //Console.WriteLine(inputStr);
            
            byte[] inputBytes = Convert.FromBase64String(inputStr);
            
            //Console.WriteLine("base64 to byte array encoded to ANSI:");
            //String ansiEncodedString = Encoding.Default.GetString(inputBytes);
            //Console.WriteLine(ansiEncodedString);
            
            //Console.WriteLine("base64 to byte array encoded to UTF8:");
            //String utf8EncodedString = new UTF8Encoding(true).GetString(inputBytes);
            //Console.WriteLine(utf8EncodedString);

            using (MemoryStream memStream = new MemoryStream(inputBytes))
            {
                using (PdfReader pdfreader = new PdfReader(memStream))
                {
                    using (PdfWriter pdfwriter = new PdfWriter(DEST_OUT))
                    {
                        using (PdfDocument pdfdoc = new PdfDocument(pdfreader, pdfwriter))
                        {
                            using (Document doc = new Document(pdfdoc))
                            {
                                doc.Add(new Paragraph("_____________________________________________!!!"));
                                doc.Add(new Paragraph("______________________________---------EY 1!"));
                                doc.Add(new Paragraph("______________________________~~~~~~~~~ahah cool EY 1!"));
                                doc.Add(new Paragraph("______________________________´´´´´´´´´hah cool EY 1!"));                                

                                doc.Close();
                            }
                        }                        
                    }
                }
                //Console.WriteLine("PDF to byte array to ANSI to console");
                Console.WriteLine(Encoding.Default.GetString(memStream.ToArray()));
                //return myoutPDF.ToArray();
            }
        }
    }
}
