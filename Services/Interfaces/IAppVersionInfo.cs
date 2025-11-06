	namespace BlazorServer.Services.Interfaces;
    public interface IAppVersionInfo
	{
		string BuildId { get; }
		string BuildNumber { get; }
		string GitHash { get; }
		string ShortGitHash { get; }
	}