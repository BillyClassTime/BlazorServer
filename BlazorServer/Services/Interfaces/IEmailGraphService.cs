namespace BlazorServer.Services.Interfaces;
public interface IEmailGraphService
{
    Task SendAsync(string to, string subject, string body);
}