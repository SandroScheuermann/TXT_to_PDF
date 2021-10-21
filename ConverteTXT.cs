using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;

namespace TXT_to_PDF
{
    class ConverteTXT
    {
        public static ILogger<Worker> Logger = Worker.Logger;
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
            Logger.LogInformation("\nArquivo {arquivo} convertido com sucesso\n", arquivo.Name);
            pdf.Close();

        }
    }
}
