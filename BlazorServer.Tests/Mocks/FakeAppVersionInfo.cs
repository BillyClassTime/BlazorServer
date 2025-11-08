using BlazorServer.Infrastructure.Interfaces;

namespace BlazorServer.Tests.Mocks;
public class FakeAppVersionInfo : IAppVersionInfo
{
    public string Version => "TestVersion";
    public DateTime BuildDate => DateTime.UtcNow;

    public string BuildId => string.Empty;

    public string BuildNumber => string.Empty;

    public string GitHash => string.Empty;

    public string ShortGitHash => string.Empty;
}
