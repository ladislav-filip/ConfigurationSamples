#region Info

// FileName:    SubWorkerOptSnap.cs
// Author:      Ladislav Filip
// Created:     04.06.2022

#endregion

using Microsoft.Extensions.Options;

namespace ConsoleSample;

public class SubWorkerOptSnap
{
    private readonly IOptionsSnapshot<MySetting> _opt;
    private readonly ILogger<SubWorkerOptSnap> _logger;

    public SubWorkerOptSnap(IOptionsSnapshot<MySetting> opt, ILogger<SubWorkerOptSnap> logger)
    {
        _opt = opt;
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("SubWorkerOptSnap settings is {Text}", _opt.Value.MyTextValue);
    }
}