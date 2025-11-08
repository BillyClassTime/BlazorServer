using Bunit;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop.Infrastructure;
using Microsoft.JSInterop;
using Moq;
using BlazorServer.Pages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorServer.Tests.Components;

public class DomoticaDigitalHomeTests : TestContext
{
    private readonly Mock<IJSRuntime> _mockJsRuntime;

    public DomoticaDigitalHomeTests()
    {
        // 1. Inicializar Moq para IJSRuntime
        _mockJsRuntime = new Mock<IJSRuntime>();

        // CONFIGURACIÓN CRÍTICA: Simula el comportamiento de InvokeAsync.
        // Esto previene el InvalidCastException al obligar al mock a devolver el tipo esperado (IJSVoidResult).
        _mockJsRuntime
            .Setup(x => x.InvokeAsync<IJSVoidResult>(It.IsAny<string>(), It.IsAny<object[]>()))
            // Devuelve un ValueTask que contiene un mock de IJSVoidResult
            .Returns(new ValueTask<IJSVoidResult>(Mock.Of<IJSVoidResult>()));

        // 2. Registrar las inyecciones en el contexto de bUnit
        Services.AddSingleton(_mockJsRuntime.Object); // Inyectamos la instancia Mock
        Services.AddSingleton(Mock.Of<ILogger<DomoticaDigitalHome>>());
    }

    [Fact]
    public void DomoticaDigitalHome_ShouldRenderWithoutErrors()
    {
        // ACT: Renderizar el componente
        var cut = RenderComponent<DomoticaDigitalHome>();

        // ASSERT: 
        Assert.NotNull(cut.Markup);
        Assert.Contains("DOMÓTICA PARA EL HOGAR DIGITAL", cut.Markup);
    }

    [Fact]
    public async Task AnchorClick_ShouldInvokeJsRuntimeToNavigate()
    {
        // ARRANGE
        var expectedAnchorId = "servicios";
        var cut = RenderComponent<DomoticaDigitalHome>();

        var anchor = cut.Find("a.btn-primary");

        // ACT: Simular el clic
        await anchor.ClickAsync(new MouseEventArgs());

        // ASSERT: Verificar que se llamó al método de Moq
        // 1. Verificamos la función ("navigateToAnchor") y el tipo de retorno (<IJSVoidResult>)
        _mockJsRuntime.Verify(
            x => x.InvokeAsync<IJSVoidResult>(
                "navigateToAnchor",
                // 2. Usamos object[] para capturar los argumentos
                It.Is<object[]>(args =>
                    args.Length == 1 && args[0].ToString() == expectedAnchorId)
            ),
            Times.Once(),
            "Se esperaba la llamada a navigateToAnchor con el ID correcto."
        );
    }
}