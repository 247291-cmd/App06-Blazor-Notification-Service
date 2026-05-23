namespace App06_Notifications.Services;

public class NotificationService
{
    private readonly NotificationConfig _config;
    private static readonly string[] Samples = [
        "New message from Dr. Abdul Hameed",
        "Assignment 4 is due in 3 days",
        "Your submission was received successfully",
        "New announcement posted in the portal",
        "Grade updated for Lab 3",
        "New reply in the discussion forum",
        "Reminder: Project presentation on Friday",
        "System maintenance scheduled for Sunday",
        "New email from the department",
        "You earned a participation badge!"
    ];

    public NotificationService(NotificationConfig config) => _config = config;

    public Task<List<NotificationItem>> GetNotificationsAsync(int? count = null)
    {
        var n = Math.Clamp(count ?? _config.DefaultNumberOfNotifications, 1, Samples.Length);
        var result = Samples.Take(n).Select((msg, i) => new NotificationItem
        {
            Id = i + 1, Message = msg,
            Timestamp = DateTime.Now.AddMinutes(-(i * 15)),
            IsRead = i > 1
        }).ToList();
        return Task.FromResult(result);
    }
}

public class NotificationItem
{
    public int Id { get; set; }
    public string Message { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public bool IsRead { get; set; }
}
