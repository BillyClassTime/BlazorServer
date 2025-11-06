using BlazorServer.Configuration.Interfaces;
namespace BlazorServer.Configuration;
public class EntraIdGraphSettings : IEntraIdGraphSettings
{
    public string? TenantId { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? Sender { get; set; }
}
