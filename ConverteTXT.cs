using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using System.Linq;

namespace TXT_to_PDF
{
    class ConverteTXT
    {
        public static void Converter(FileStream arquivo)
        {
            var nomeArquivoCompleto = arquivo.Name.Split('\\').ToList().Last();
            var nomeArquivo = nomeArquivoCompleto.Split('.').ToList().First() + ".pdf";

            var writer = new PdfWriter(JsonConfig.Out_PDF + $"\\{nomeArquivo}");
            var pdfDocument = new PdfDocument(writer);
            var pdf = new Document(pdfDocument);         

            StreamReader arquivoFileStream = new StreamReader(arquivo);

            string conteudoTXT = arquivoFileStream.ReadToEnd();

            pdf.Add(new Paragraph(conteudoTXT));

            pdf.Close();

        }
    }
}
