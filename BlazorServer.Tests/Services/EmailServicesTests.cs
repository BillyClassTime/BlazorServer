using BlazorServer.Configuration;
using BlazorServer.Models;            
using BlazorServer.Services;           // EmailGraphService, GraphClientWrapper
using BlazorServer.Services.Interfaces; // IEmailGraphService, IGraphClientWrapper
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph.Models;
using Moq;
using Xunit;

public class EmailGraphServiceTests
{
    private readonly Mock<ILogger<EmailGraphService>> _mockLogger;
    private readonly Mock<IGraphClientWrapper> _mockGraphClient;
    private readonly EntraIdGraphSettings _settings;
    private readonly IOptions<EntraIdGraphSettings> _mockOptions;

    // Configuración de las dependencias que serán inyectadas
    public EmailGraphServiceTests()
    {
        _mockLogger = new Mock<ILogger<EmailGraphService>>();
        _mockGraphClient = new Mock<IGraphClientWrapper>();

        // 1. Configuración Falsa (ARRANGE GLOBAL)
        _settings = new EntraIdGraphSettings
        {
            Sender = "sistema@fakesender.com",
            TenantId = "fake-tenant-id",
            ClientId = "fake-client-id",
            ClientSecret= "fake-client-secret"
        };
        _mockOptions = Options.Create(_settings);
    }

    [Fact]
    public async Task SendAsync_ShouldCallGraphClientExactlyTwiceForTwoMessages()
    {
        // ARRANGE
        // Instanciamos el servicio, inyectando las dependencias simuladas
        var service = new EmailGraphService(
            _mockOptions,
            _mockLogger.Object,
            _mockGraphClient.Object // <--- ¡La clave!
        );

        var recipient = "usuario@test.com";
        var subject = "Consulta de prueba";
        var body = "Este es un mensaje de prueba para el mock.";

        // ACT
        await service.SendAsync(recipient, subject, body);

        // ASSERT
        // Verificamos que el método SendMailAsync del mock fue llamado 2 veces.
        // La prueba es exitosa si el servicio llamó a su cliente dos veces, 
        // ¡probando tu lógica de negocio de envío doble!
        _mockGraphClient.Verify(
            x => x.SendMailAsync(
                _settings.Sender!, // El remitente configurado
                It.IsAny<Message>()), // Cualquier objeto Message
            Times.Exactly(2)
        );
    }

    [Fact]
    public async Task SendAsync_FirstCallShouldContainOriginalSubject()
    {
        // ARRANGE
        var service = new EmailGraphService(_mockOptions, _mockLogger.Object, _mockGraphClient.Object);
        var originalSubject = "Asunto Único del Cliente";

        // ACT
        await service.SendAsync("a@b.com", originalSubject, "body");

        // ASSERT
        // Verificamos que el MOCK recibió una llamada con el asunto original.
        // Aquí usamos una función de predicado (It.Is<...>) para inspeccionar el objeto Message que recibió el mock.
        _mockGraphClient.Verify(
            x => x.SendMailAsync(
                _settings.Sender!,
                It.Is<Message>(msg => msg.Subject == originalSubject)), // Inspección
            Times.Once()
        );
    }

    // Aquí añadiremos más pruebas, como verificar que el LogInformation se llama
}