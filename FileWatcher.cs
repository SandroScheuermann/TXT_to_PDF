using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace TXT_to_PDF
{
    public class FileWatcher
    {
        public static ILogger<Worker> Logger = Worker.Logger;

        private static TimeSpan tempoDecorrido = new TimeSpan();

        public static FileSystemWatcher Iniciar()
        {
            var watcher = new FileSystemWatcher(JsonConfig.In_TXT);

            watcher.Created += new FileSystemEventHandler(OnCreated);

            watcher.IncludeSubdirectories = false;

            watcher.EnableRaisingEvents = true;

            Logger.LogInformation("\nVerificou o diretório {diretorio}: \n", JsonConfig.In_TXT);

            return watcher;
        }
        private static async void OnCreated(object sender, FileSystemEventArgs arquivo)
        {
            Logger.LogInformation("\nOnCreated chamado com arquivo : {arquivo.FullPath}\n", arquivo.FullPath);

            Stopwatch sw = Stopwatch.StartNew();

            await Task.Run(() => ConverteTXT.Converter(new FileStream(arquivo.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read)));

            sw.Stop();

            if (sw.Elapsed > tempoDecorrido)
                tempoDecorrido = sw.Elapsed;

            Console.WriteLine("MAIOR TEMPO DECORRIDO :" + tempoDecorrido.ToString());
        }
    }
}
