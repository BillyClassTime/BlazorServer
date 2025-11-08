using Azure.Identity;
using BlazorServer.Configuration; 
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;
using BlazorServer.Services.Interfaces;

namespace BlazorServer.Services;
public class GraphClientWrapper : IGraphClientWrapper
{
    private readonly EntraIdGraphSettings _cfg;
    private readonly GraphServiceClient _graphClient;

    public GraphClientWrapper(IOptions<EntraIdGraphSettings> options)
    {
        _cfg = options.Value;

        // --- 🚨 Lógica de Inicialización de Red (MOVIDA DESDE SendAsync) 🚨 ---
        var credential = new ClientSecretCredential(
             _cfg.TenantId!,
             _cfg.ClientId!,
             _cfg.ClientSecret!
        );
        _graphClient = new GraphServiceClient(credential);
    }

    public async Task SendMailAsync(string sender, Message message)
    {
        // --- 🚨 Lógica de Llamada a Graph (MOVIDA DESDE SendAsync) 🚨 ---
        await _graphClient.Users[sender].SendMail
             .PostAsync(new SendMailPostRequestBody
             {
                 Message = message,
                 SaveToSentItems = true
             });
    }
}