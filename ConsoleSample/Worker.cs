#region Info
// FileName:    Worker.cs
// Author:      Ladislav Filip
// Created:     04.06.2022
#endregion

using Microsoft.Extensions.Options;

namespace ConsoleSample;

public class Worker
{
    private readonly ILogger<Worker> _logger;
    private readonly IOptionsMonitor<MySetting> _opt;

    public Worker(ILogger<Worker> logger, IOptionsMonitor<MySetting> opt)
    {
        _logger = logger;
        _opt = opt;
    }

    public void Run()
    {
        do
        {
            _logger.LogInformation("---");
            // _logger.LogInformation("Working with setting {Text}", _opt.CurrentValue.MyTextValue);
            var sub = Helper.Provider.GetRequiredService<SubWorkerOpt>();
            sub.Run();
            var subSnap = Helper.Provider.GetRequiredService<SubWorkerOptSnap>();
            subSnap.Run();
            var subMon = Helper.Provider.GetRequiredService<SubWorkerOptMonitor>();
            subMon.Run();
            var subConf = Helper.Provider.GetRequiredService<SubWorkerConfiguration>();
            subConf.Run();
            Thread.Sleep(3000);
        } while (true);
    }
}