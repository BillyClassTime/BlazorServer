using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using BlazorServer.Services.Interfaces; // IEmailGraphService está aquí
using BlazorServer.Services;
using BlazorServer.Configuration;            // Donde está la clase EmailGraphService

public class EmailGraphServiceTests
{
    // Usaremos un Mock para el ILogger<T>
    private readonly Mock<ILogger<EmailGraphService>> _mockLogger;
    
    public EmailGraphServiceTests()
    {
        // Inicializar el Mock de ILogger una sola vez.
        // ILogger<T> es muy fácil de simular porque no tiene métodos complejos que necesitemos programar.
        _mockLogger = new Mock<ILogger<EmailGraphService>>();
    }

    [Fact]
    public async Task SendAsync_ShouldLogInformationOnSuccess()
    {
        // 1. Arrange (Preparación de las dependencias)

        // a) Preparar la configuración usando Moq y IOptions<T>
        var settings = new EntraIdGraphSettings
        {
            TenantId = "fake-tenant-id",
            ClientId = "fake-client-id",
            ClientSecret = "fake-client-secret",
            Sender = "sender@fakecompany.com"
        };

        // Creamos una implementación real de IOptions<T> que envuelve nuestra configuración falsa.
        var mockOptions = Options.Create(settings); 

        // b) Preparar el Logger (ya inicializado en el constructor de la prueba)
        // No necesitamos programarlo a menos que queramos verificar que se llamó a LogInformation().

        // c) Instanciar el servicio bajo prueba, pasando las dependencias:
        var emailService = new EmailGraphService(
            mockOptions,          // Provee la configuración (IOptions<T>)
            _mockLogger.Object    // Provee el logger simulado (ILogger<T>)
        );

        var recipient = "test@user.com";
        var subject = "Test Subject";
        var body = "Test Body";

        // 2. Act (Acción)
        // Nota: El método SendAsync de tu servicio es asíncrono.
        await emailService.SendAsync(recipient, subject, body); 

        // 3. Assert (Verificación)

        // Lo que realmente se debería probar en esta capa:
        // * Que se registra (LogInformation) el inicio del envío.
        // * Que se lanzó una excepción si la configuración es nula.
        // * Que se construyeron los objetos de correo Message/SendMailPostRequestBody correctamente.

        // Ejemplo de verificación de log:
        // Verifica que se llamó a LogInformation al menos una vez, 
        // con el nivel y el mensaje de log esperado (requiere una sintaxis compleja con Moq.Es.IsAny)

        // Por ejemplo, verificar que se llamó al menos una vez al logger:
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
            Times.AtLeastOnce());

        // NOTA: No podemos probar la interacción con Microsoft Graph ni Azure.Identity 
        // porque no los estamos simulando (mockeando). 
        // Para simular el flujo de Graph, tendrías que inyectar una interfaz para 
        // el GraphServiceClient (ej. IGraphServiceClientWrapper) en lugar de crearlo internamente.
    }
}