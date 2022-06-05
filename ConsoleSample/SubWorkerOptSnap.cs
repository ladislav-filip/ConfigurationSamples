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
    private readonly string _id = Guid.NewGuid().ToString();

    public SubWorkerOptSnap(IOptionsSnapshot<MySetting> opt, ILogger<SubWorkerOptSnap> logger)
    {
        _opt = opt;
        _logger = logger;
    }
    
    public void Run(string ident = "")
    {
        _logger.LogInformation(ident + "IOptionsSnapshot [{Id}] settings is {Text}", _id, _opt.Value.MyTextValue);
    }
}
