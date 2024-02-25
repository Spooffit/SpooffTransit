using Microsoft.AspNetCore.Mvc;

namespace SpooffTransit.Publisher.Controllers;

[ApiController]
[Route("[controller]")]
public class MassTransitController : ControllerBase
{
    public MassTransitController()
    {
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("kek");
    }
}