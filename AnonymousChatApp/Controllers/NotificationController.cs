using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly ChatDbContext _context;

    public NotificationsController(ChatDbContext context)
    {
        _context = context;
    }

    [HttpPost("mute/{userId}")]
    public async Task<IActionResult> MuteNotifications(int userId)
    {
        var notification = await _context.Notifications.FirstOrDefaultAsync(n => n.UserId == userId);

        if (notification == null)
        {
            notification = new Notification { UserId = userId, IsMuted = true };
            _context.Notifications.Add(notification);
        }
        else
        {
            notification.IsMuted = true;
        }

        await _context.SaveChangesAsync();

        return Ok(notification);
    }
}
