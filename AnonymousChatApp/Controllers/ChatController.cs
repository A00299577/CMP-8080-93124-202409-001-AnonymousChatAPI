using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly ChatDbContext _context;

    public ChatController(ChatDbContext context)
    {
        _context = context;
    }

    [HttpPost("message")]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
    {
        message.Timestamp = DateTime.Now;

        _context.ChatMessages.Add(message);
        await _context.SaveChangesAsync();

        return Ok(message);
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetChatHistory()
    {
        var messages = await _context.ChatMessages
            .Include(m => m.User)
            .OrderByDescending(m => m.Timestamp)
            .Take(100)
            .ToListAsync();

        return Ok(messages);
    }
}
