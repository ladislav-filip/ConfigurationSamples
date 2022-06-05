#region Info

// FileName:    SubWorkerConfiguration.cs
// Author:      Ladislav Filip
// Created:     04.06.2022

#endregion

namespace ConsoleSample;

public class SubWorkerConfiguration
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<SubWorkerConfiguration> _logger;

    public SubWorkerConfiguration(IConfiguration configuration, ILogger<SubWorkerConfiguration> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("IConfiguration settings is {Text}", _configuration.GetValue<string>("my:MyTextValue"));
    }
}