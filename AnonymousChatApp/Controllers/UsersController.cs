using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ChatDbContext _context;

    public UsersController(ChatDbContext context)
    {
        _context = context;
    }

    [HttpPost("join")]
    public async Task<IActionResult> JoinChat()
    {
        var user = new User
        {
            Username = "User_" + Guid.NewGuid().ToString("N").Substring(0, 6),
            SessionId = Guid.NewGuid().ToString()
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}
