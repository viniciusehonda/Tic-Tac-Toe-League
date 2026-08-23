using Microsoft.AspNetCore.Mvc;

namespace TicTacToeLeague.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "healthy",
            service = "TicTacToeLeague.Api",
            timestamp = DateTime.UtcNow
        });
    }
}
