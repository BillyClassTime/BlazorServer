using System.Reflection;
using BlazorServer.Services.Interfaces;
namespace BlazorServer.Services;
public class AppVersionInfo : IAppVersionInfo
{
    private static readonly string _buildFileName = ".buildinfo.json";
    private readonly Lazy<string> _buildNumber;
    private readonly Lazy<string> _buildId;
    private readonly Lazy<string> _gitHash;
    private readonly Lazy<string> _gitShortHash;

    public AppVersionInfo(IHostEnvironment? hostEnvironment)
    {
        var buildFilePath = Path.Combine(hostEnvironment!.ContentRootPath, _buildFileName);
        var buildInfo = LoadBuildInfo(buildFilePath);
        _buildNumber = new Lazy<string>(() => GetBuildNumber(buildInfo));
        _buildId = new Lazy<string>(() => GetBuildId(buildInfo));
        _gitHash = new Lazy<string>(GetGitHash);
        _gitShortHash = new Lazy<string>(() => GetShortGitHash(_gitHash.Value));
    }

    public string BuildNumber => _buildNumber.Value;

    public string BuildId => _buildId.Value;

    public string GitHash => _gitHash.Value;

    public string ShortGitHash => _gitShortHash.Value;

    private static (string Number, string Id) LoadBuildInfo(string buildFilePath)
    {
        try
        {
            var fileContents = File.ReadLines(buildFilePath).ToList();
            var buildNumber = fileContents.Count > 0 ? fileContents[0] : null;
            var buildId = fileContents.Count > 1 ? fileContents[1] : null;
            return (buildNumber!, buildId!);
        }
        catch 
        {
            // Log or handle the exception as needed
            return (null!, null!);
        }
    }

    private static string GetBuildNumber((string Number, string Id) buildInfo)
    {
        return !string.IsNullOrEmpty(buildInfo.Number) ? buildInfo.Number : DateTime.UtcNow.ToString("yyyyMMdd") + ".0";
    }

    private static string GetBuildId((string Number, string Id) buildInfo)
    {
        return !string.IsNullOrEmpty(buildInfo.Id) ? buildInfo.Id : "123456";
    }

    private static string GetGitHash()
    {
        var version = "1.0.0+LOCALBUILD"; // Dummy version for local dev
        var appAssembly = typeof(AppVersionInfo).Assembly;
        var infoVerAttr = (AssemblyInformationalVersionAttribute)appAssembly!
            .GetCustomAttributes<AssemblyInformationalVersionAttribute>()!.FirstOrDefault()!;

        if (infoVerAttr != null && infoVerAttr.InformationalVersion.Length > 6)
        {
            // Hash is embedded in the version after a '+' symbol, e.g. 1.0.0+a34a913742f8845d3da5309b7b17242222d41a21
            version = infoVerAttr.InformationalVersion;
        }
        return version[(version.IndexOf('+') + 1)..];
    }

    private static string GetShortGitHash(string gitHash)
    {
        return gitHash.Substring(gitHash.Length - 6, 6);
    }
}