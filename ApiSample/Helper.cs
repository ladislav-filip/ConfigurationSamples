#region Info

// FileName:    Helper.cs
// Author:      Ladislav Filip
// Created:     05.06.2022

#endregion

using Serilog.Core;

namespace ApiSample;

public static class Helper
{
    public static LoggingLevelSwitch LogLevel { get; } = new();

    public static IConfigurationBuilder CustomConf(this IConfigurationBuilder confBuilder)
    {
        confBuilder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false, reloadOnChange: false)
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                true, reloadOnChange: false)
            .AddJsonFile("appsettings.local.json", true)
            .AddEnvironmentVariables()
            .AddSystemsManager("/samples", reloadAfter: TimeSpan.FromSeconds(30));

        return confBuilder;
    }
}