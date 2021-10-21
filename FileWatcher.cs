using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXT_to_PDF
{
    public class FileWatcher
    {
        private static ILogger<Worker> Logger;

        public static void Iniciar(ILogger<Worker> _logger)
        {
            Logger = _logger;
            VerificarDiretorios();
        }

        private static void VerificarDiretorios()
        {
            var watcher = new FileSystemWatcher(JsonConfig.In_TXT);

            watcher.Created += new FileSystemEventHandler(OnCreated);

            watcher.IncludeSubdirectories = false;

            watcher.EnableRaisingEvents = true;

            Logger.LogInformation("Verificou o diretório {diretorio}: ", JsonConfig.In_TXT);
        }
        private static void OnCreated(object sender, FileSystemEventArgs arquivo)
        {
            Logger.LogInformation("OnCreated chamado com arquivo : {arquivo.FullPath}", arquivo.FullPath);

            Task.Run(() => ConverteTXT.Converter(new FileStream(arquivo.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read)));
        }
    }
}
