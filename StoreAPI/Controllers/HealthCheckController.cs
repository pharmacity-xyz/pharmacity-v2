using BusinessObjects.Models;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using StoreAPI.Storage;

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

