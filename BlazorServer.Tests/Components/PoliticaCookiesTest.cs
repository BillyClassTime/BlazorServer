using BlazorServer.Pages;
using Bunit;

namespace BlazorServer.Tests.Components;


public class PoliticaCookiesTests : TestContext
{
    [Fact]
    public void PoliticaCookies_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 1. SI PoliticaCookies inyecta ILogger<PoliticaCookies>, DESCOMENTA esta línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<PoliticaCookies>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<PoliticaCookies>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("Al aceptar el banner de cookies, consientes el uso de las cookies descritas.", cut.Markup);
    }
}
// ------------------------------------------