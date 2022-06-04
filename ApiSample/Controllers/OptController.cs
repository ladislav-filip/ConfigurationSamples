#region Info

// FileName:    OptController.cs
// Author:      Ladislav Filip
// Created:     04.06.2022

#endregion

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiSample.Controllers;

[ApiController]
[Route("[controller]")]
public class OptController : ControllerBase
{
    private readonly ILogger<OptController> _logger;
    private readonly IOptionsMonitor<MySetting> _optMonitor;
    private readonly IConfiguration _configuration;
    private readonly IOptionsSnapshot<MySetting> _optSnap;
    private readonly IOptions<MySetting> _opt;

    public OptController(ILogger<OptController> logger, 
        IOptionsMonitor<MySetting> optMonitor, 
        IConfiguration configuration,
        IOptionsSnapshot<MySetting> optSnap,
        IOptions<MySetting> opt)
    {
        _logger = logger;
        _optMonitor = optMonitor;
        _configuration = configuration;
        _optSnap = optSnap;
        _opt = opt;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = $"Monitor: value = {_optMonitor.CurrentValue.MyTextValue}\r\n";
        result += $"Snap: value = {_optSnap.Value.MyTextValue}\r\n";
        result += $"Opt: value = {_opt.Value.MyTextValue}\r\n";
        result += "Configuration: value = " + _configuration.GetValue<string>("my:MyTextValue");
        
        return Ok(result);
    }
}