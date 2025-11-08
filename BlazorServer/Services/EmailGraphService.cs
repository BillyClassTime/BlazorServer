using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;
using BlazorServer.Services.Interfaces;
using BlazorServer.Configuration.Interfaces;
using BlazorServer.Configuration;

namespace BlazorServer.Services;
public class EmailGraphService : IEmailGraphService
{
    private readonly IGraphClientWrapper _graphClientWrapper;
    private readonly IEntraIdGraphSettings _cfg;
    private readonly ILogger<EmailGraphService> _log;

    public EmailGraphService(IOptions<EntraIdGraphSettings> options,
                             ILogger<EmailGraphService> log,
                             IGraphClientWrapper graphClientWrapper)
    {
        _cfg = options.Value;
        _log = log;
        if (string.IsNullOrEmpty(_cfg.Sender) || string.IsNullOrEmpty(_cfg.TenantId))
        {
            _log.LogError("Configuración de EntraIdGraphSettings incompleta o faltante. No se podrá enviar el correo.");
        }

        _graphClientWrapper = graphClientWrapper;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        // 1. Crear credenciales con Azure.Identity
        _log.LogInformation("Intentando enviar correo a: {To} con asunto: {Subject}", to, subject);
        
        // 3. Construir el mensaje para recibir desde el formulario de contacto
        var message = new Message
        {
            Subject = subject,
            Body = new ItemBody
            {
                ContentType = BodyType.Text,
                Content = body
            },
            ToRecipients = new List<Recipient>
            {
                new Recipient
                {
                    EmailAddress = new EmailAddress { Address = _cfg.Sender }
                }
            }
        };

        // Mensaje de confirmación para el remitente
        var messageConfirmation = new Message
        {
            Subject = "Confirmación de correo Recibido",
            Body = new ItemBody
            {
                ContentType = BodyType.Text,
                Content = "Gracias por contactarnos. Hemos recibido su mensaje y nos pondremos en contacto con usted pronto."
            },
            ToRecipients = new List<Recipient>
            {
                new Recipient
                {
                    EmailAddress = new EmailAddress { Address = to }
                }
            }
        };

        _log!.LogInformation("Enviando correo desde {Email}", _cfg.Sender);

        // 4. Enviar el correo de recepción con el wrapper
        await _graphClientWrapper.SendMailAsync(_cfg.Sender!, message);

        // 5. Enviar el correo de confirmación con el wrapper
        await _graphClientWrapper.SendMailAsync(_cfg.Sender!, messageConfirmation);
    }
}