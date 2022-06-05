#region Info
// FileName:    SubWorkerOpt.cs
// Author:      Ladislav Filip
// Created:     04.06.2022
#endregion

using Microsoft.Extensions.Options;

namespace ConsoleSample;

public class SubWorkerOpt
{
    private readonly IOptions<MySetting> _opt;
    private readonly ILogger<SubWorkerOpt> _logger;

    public SubWorkerOpt(IOptions<MySetting> opt, ILogger<SubWorkerOpt> logger)
    {
        _opt = opt;
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("IOptions settings is {Text}", _opt.Value.MyTextValue);
    }
}