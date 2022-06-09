#region Info
// FileName:    Worker.cs
// Author:      Ladislav Filip
// Created:     04.06.2022
#endregion

namespace ConsoleSample;

public class Worker
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public void Run()
    {
        do
        {
            _logger.LogDebug("...run loop...\r\n");
            _logger.LogInformation("---\r\n");
            _logger.LogWarning("######\r\n");

            _logger.LogInformation("HODNOTA = {Hodnota}", _configuration.GetValue<string>("HODNOTA"));

            Thread.Sleep(5000);
        } while (true);
    }

    private void SubSnapStart(bool asThread, bool createScope = true)
    {
        var ident = "";
        
        void RunByScope()
        {
            SubWorkerOptSnap subSnapThread;
            if (createScope)
            {
                _logger.LogInformation(ident + "Create new scope...");
                using var scope = Helper.Provider.CreateScope();
                subSnapThread = scope.ServiceProvider.GetRequiredService<SubWorkerOptSnap>();
                ident += "   -> ";
            }
            else
            {
                subSnapThread = Helper.Provider.GetRequiredService<SubWorkerOptSnap>();
            }

            subSnapThread.Run(ident);
        }

        if (asThread)
        {
            ident = "   -> ";
            _logger.LogInformation("Start Thread...");
            var thr = new Thread(RunByScope);
            thr.Start();
            thr.Join();
        }
        else
        {
            RunByScope();
        }
    }

     
}