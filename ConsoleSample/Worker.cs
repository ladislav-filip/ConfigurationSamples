#region Info
// FileName:    Worker.cs
// Author:      Ladislav Filip
// Created:     04.06.2022
#endregion

namespace ConsoleSample;

public class Worker
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        do
        {
            _logger.LogDebug("...run loop...\r\n");
            _logger.LogInformation("---\r\n");
            _logger.LogWarning("######\r\n");

            Thread.Sleep(5000);
        } while (true);
    }
    

     
}