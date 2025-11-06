using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;


public class EmailServiceGraph
{
    private readonly AzureAdGraphSettings _cfg;

    public EmailServiceGraph(IOptions<AzureAdGraphSettings> options)
    {
        _cfg = options.Value;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        // 1. Crear credenciales con Azure.Identity
        var credential = new ClientSecretCredential(
            _cfg.TenantId,
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

        Console.WriteLine($"Enviando correo desde {_cfg.Sender}" );
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

public class AzureAdGraphSettings
{
    public string? TenantId { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? Sender { get; set; }
}
