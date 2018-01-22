using System;
using System.Drawing.Printing;
using System.IO;
using PdfiumViewer;

namespace mime_print
{
    public static class pdf_print
    {
        public static void print(String printerAddress, byte[] data, String documentName) {
            using (var stream = new MemoryStream(data)) {
                stream.Position = 0;

                var pdfium_doc = PdfDocument.Load(stream);

                var pdf_doc = new PrintDocument();
                var prntcnt = new StandardPrintController();

                pdf_doc.PrinterSettings.PrinterName = printerAddress;
                pdf_doc.PrintController = prntcnt;
                pdf_doc.DocumentName = documentName;
                pdf_doc = pdfium_doc.CreatePrintDocument();

                pdf_doc.Print();
                pdf_doc.Dispose();
                pdfium_doc.Dispose();
            }
        }
    }
}
