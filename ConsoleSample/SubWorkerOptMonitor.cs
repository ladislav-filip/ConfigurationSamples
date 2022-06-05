#region Info

// FileName:    SubWorkerOptMonitor.cs
// Author:      Ladislav Filip
// Created:     04.06.2022

#endregion

using Microsoft.Extensions.Options;

namespace ConsoleSample;

public class SubWorkerOptMonitor
{
    private readonly IOptionsMonitor<MySetting> _opt;
    private readonly ILogger<SubWorkerOptMonitor> _logger;

    public SubWorkerOptMonitor(IOptionsMonitor<MySetting> opt, ILogger<SubWorkerOptMonitor> logger)
    {
        _opt = opt;
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("IOptionsMonitor settings is {Text}", _opt.CurrentValue.MyTextValue);
    }
}