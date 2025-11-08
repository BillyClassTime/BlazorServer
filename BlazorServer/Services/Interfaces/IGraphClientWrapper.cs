using Microsoft.Graph.Models;
namespace BlazorServer.Services.Interfaces;
public interface IGraphClientWrapper
{
    /// <summary>
    /// Envía un mensaje de correo usando el cliente de Microsoft Graph.
    /// </summary>
    /// <param name="sender">El correo del usuario que envía el mensaje (sacado de la configuración).</param>
    /// <param name="message">El objeto Message construido.</param>
    Task SendMailAsync(string sender, Message message);
}
