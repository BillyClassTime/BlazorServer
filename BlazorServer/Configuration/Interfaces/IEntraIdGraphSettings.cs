namespace BlazorServer.Configuration.Interfaces;
public interface IEntraIdGraphSettings
{
    string? TenantId { get; set; }
    string? ClientId { get; set; }
    string? ClientSecret { get; set; }
    string? Sender { get; set; }
}