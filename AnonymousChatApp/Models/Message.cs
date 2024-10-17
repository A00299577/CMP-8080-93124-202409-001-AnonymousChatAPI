public class ChatMessage
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}

