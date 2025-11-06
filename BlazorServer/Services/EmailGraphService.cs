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
    private readonly IEntraIdGraphSettings _cfg;
    private readonly ILogger<EmailGraphService> _log;

    public EmailGraphService(IOptions<EntraIdGraphSettings> options,
                             ILogger<EmailGraphService> log)
    {
        _cfg = options.Value;
        _log = log;
        if (string.IsNullOrEmpty(_cfg.Sender) || string.IsNullOrEmpty(_cfg.TenantId))
        {
            _log.LogError("Configuración de EntraIdGraphSettings incompleta o faltante. No se podrá enviar el correo.");
        }
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        // 1. Crear credenciales con Azure.Identity
        _log.LogInformation("Intentando enviar correo a: {To} con asunto: {Subject}", to, subject);
        if (string.IsNullOrEmpty(_cfg.Sender))
        {
            _log.LogError("Error fatal: la dirección del remitente (Sender) no esta configurada");
            throw new InvalidOperationException("La configuración del remitene es obligatoria");
        }

        var credential = new ClientSecretCredential(
            _cfg!.TenantId,
            _cfg.ClientId,
            _cfg.ClientSecret);

        // 2. Crear GraphServiceClient
        var graphClient = new GraphServiceClient(credential);

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
        
        // 4. Enviar el correo de recepción
        await graphClient.Users[_cfg.Sender].SendMail
            .PostAsync(new SendMailPostRequestBody
            {
                Message = message,
                SaveToSentItems = true
            });

        // 5. Enviar el correo de confirmación
        await graphClient.Users[_cfg.Sender].SendMail
            .PostAsync(new SendMailPostRequestBody
            {
                Message = messageConfirmation,
                SaveToSentItems = true
            });
    }
}