using ApiSample;
using Serilog;
using Serilog.Events;

Helper.LogLevel.MinimumLevel = LogEventLevel.Warning;

var configuration = new ConfigurationBuilder()
    .CustomConf()
    .Build();

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    // .MinimumLevel.ControlledBy(Helper.LogLevel)
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host
    .UseSerilog()
    .ConfigureAppConfiguration(conf =>
    {
        conf.CustomConf();
    });

// Add services to the container.

builder.Services.Configure<MySetting>(builder.Configuration.GetSection("my"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();