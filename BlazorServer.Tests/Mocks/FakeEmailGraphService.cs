using BlazorServer.Services.Interfaces;

namespace BlazorServer.Tests.Mocks;
public class FakeEmailGraphService : IEmailGraphService
{
    public Task SendAsync(string to, string subject, string body) => Task.CompletedTask;
}