using ConsoleSample;
using Serilog;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var services = new ServiceCollection();

services.Configure<MySetting>(configuration.GetSection("my"));

services.AddSingleton<Worker>();
services.AddSingleton<IConfiguration>(configuration);
services.AddTransient<SubWorkerOpt>();
services.AddTransient<SubWorkerOptSnap>();

services.AddTransient<SubWorkerOptMonitor>();
services.AddTransient<SubWorkerConfiguration>();
services.AddLogging(conf =>
{
    conf.AddSerilog(dispose: true);
    // conf.AddConfiguration(configuration);
    // conf.AddConsole();
});

var serviceProvider = services.BuildServiceProvider();
Helper.Provider = serviceProvider;

var worker = serviceProvider.GetRequiredService<Worker>();

worker.Run();