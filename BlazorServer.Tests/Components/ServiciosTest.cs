using BlazorServer.Pages;
using Bunit;

namespace BlazorServer.Tests.Components;

public class ServiciosTests : TestContext
{
    [Fact]
    public void Servicios_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 1. SI Servicios inyecta ILogger<Servicios>, DESCOMENTA esta línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<Servicios>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<Servicios>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("acciones específicas y más eficientes.", cut.Markup);
    }
}
