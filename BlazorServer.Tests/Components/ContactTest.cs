using Bunit;
using Moq;
using BlazorServer.Pages;
using BlazorServer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorServer.Tests.Mocks;

namespace BlazorServer.Tests.Components;

public class ContactTests : TestContext
{
    private readonly Mock<IEmailGraphService> _mockEmailService;

    public ContactTests()
    {
        // 1. FIX CRUCIAL: Aumentar el tiempo de espera por defecto para peticiones asíncronas
        TestContext.DefaultWaitTimeout = TimeSpan.FromSeconds(10);

        _mockEmailService = new Mock<IEmailGraphService>();

        // Aseguramos que SendAsync siempre devuelve una Tarea completada exitosamente.
        _mockEmailService.Setup(x => x.SendAsync(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        Services.AddSingleton(_mockEmailService.Object);
        Services.AddSingleton(Mock.Of<ILogger<Contact>>());

        // Registrar el FakeCaptchaService
        Services.AddSingleton<ICaptchaService, FakeCaptchaService>();
    }

    [Fact]
    public async Task FormSubmit_ShouldCallSendAsyncAndShowSuccessMessage()
    {
        // ARRANGE
        var testName = "Prueba BUnit";
        var testEmail = "usuario_test@bunit.com";
        var testPhone = "555-123456";
        var testMessage = "Contenido del mensaje desde bUnit.";
        var expectedSuccessMessage = "Mensaje enviado correctamente. Gracias por contactar con nosotros.";

        var cut = RenderComponent<Contact>();

        // 1. Simular la entrada de datos
        cut.Find("#name").Change(testName);
        cut.Find("#email").Change(testEmail);
        cut.Find("#phone").Change(testPhone);
        cut.Find("#message").Change(testMessage);

        // 🚨 CORRECCIÓN: Usamos "14" (como string) para que pase la validación del int 14 🚨
        cut.Find("input[type=text]").Change("14");

        // ACT
        await cut.Find("form").SubmitAsync();

        // 2. SINCRONIZACIÓN Y ASSERT (combinado)
        // Esperamos a que la UI se actualice con el mensaje de éxito. Si no ocurre en 10s, falla.
        cut.WaitForState(() => cut.Markup.Contains(expectedSuccessMessage));

        // ASSERT: Lógica de Negocio
        var expectedBody = $"Enviado desde:{testEmail}\n{testName}\n{testPhone} \n{testMessage}";

        _mockEmailService.Verify(
            x => x.SendAsync(
                testEmail,
                "Nuevo mensaje",
                expectedBody),
            Times.Once()
        );

        // 3. ASSERT: Experiencia de Usuario (Opcional, pero se mantiene para claridad)
        Assert.Contains(expectedSuccessMessage, cut.Markup);
    }
}