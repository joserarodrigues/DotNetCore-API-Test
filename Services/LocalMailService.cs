using System.Diagnostics;
using Microsoft.Extensions.Configuration;

public class LocalMailService : IMailService
{
    private string _mailTo;
    private string _mailFrom;

    public LocalMailService(IConfiguration configuration)
    {
        _mailTo = configuration["mailSettings:mailToAddress"];
        _mailFrom = configuration["mailSettings:mailFromAddress"];
    }
    public void Send(string subject, string message)
    {
        Debug.WriteLine($"Mail from {_mailTo} to {_mailFrom}");
    }
}