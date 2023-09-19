namespace N41_HT2.Models;

public class EmailTemplate
{
    public User User { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public EmailTemplate(User user, string subject, string body)
    {
        User = user;
        Subject = subject;
        Body = body;
    }
}