using Footwear.Persistance.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Footwear.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DbConnectionTestController : ControllerBase
{

    private readonly FootwearContext _context;

    public DbConnectionTestController(FootwearContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("test-connection")]
    public async Task<IActionResult> TestConnection()
    {
        try
        {
            await _context.Database.OpenConnectionAsync();
            await _context.Database.CloseConnectionAsync();
            return Ok("Connection successful!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Connection failed: {ex.Message}");
        }
    }
}
