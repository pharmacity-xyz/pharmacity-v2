using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HealthCheckController : ControllerBase
{
    public HealthCheckController()
    {
    }

    [HttpGet]
    public ActionResult HealthCheck()
    {
        return Ok();
    }
}

