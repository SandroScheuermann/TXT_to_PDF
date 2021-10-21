using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TXT_to_PDF
{
    public class Worker : BackgroundService
    {
        public static ILogger<Worker> Logger;
        private readonly FileSystemWatcher Watcher;

        public Worker(ILogger<Worker> logger)
        {
            Logger = logger;
            Watcher = FileWatcher.Iniciar();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("\nWorker running at: {time}", DateTimeOffset.Now);
                Logger.LogInformation("Threads rodando : {threads}\n", Process.GetCurrentProcess().Threads.Count);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
