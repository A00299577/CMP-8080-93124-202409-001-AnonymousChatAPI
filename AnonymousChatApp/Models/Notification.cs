public class Notification
{
    public int Id { get; set; }
    public bool IsMuted { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}

