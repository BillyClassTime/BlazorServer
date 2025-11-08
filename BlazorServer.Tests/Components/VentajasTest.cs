using BlazorServer.Pages;
using Bunit;

namespace BlazorServer.Tests.Components;

public class VentajasTests : TestContext
{
    [Fact]
    public void Ventajas_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 1. SI Ventajas inyecta ILogger<Ventajas>, DESCOMENTA esta línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<Ventajas>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<Ventajas>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("Instalaciones seguras frente a incendios, escapes de agua, gas y la acción de la climatología", cut.Markup);
    }
}
