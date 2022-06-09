﻿using ConsoleSample;
using Serilog;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .CreateLogger();

var services = new ServiceCollection();

services.Configure<MySetting>(configuration.GetSection("my"));

services.AddSingleton<Worker>();

services.AddLogging(conf =>
{
    // nuget Serilog.Settings.Reloader zajistí reload konfigurace
    conf.AddSerilog(SwitchableLogger.Instance, true)
        .AddSerilogConfigurationLoader(configuration, SwitchableLogger.Instance);
});

var serviceProvider = services.BuildServiceProvider();
Helper.Provider = serviceProvider;

var worker = serviceProvider.GetRequiredService<Worker>();

worker.Run();