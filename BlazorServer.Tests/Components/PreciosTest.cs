using BlazorServer.Pages;
using Bunit;

namespace BlazorServer.Tests.Components;

// ESTA ES LA PLANTILLA A COPIAR Y ADAPTAR:
// ------------------------------------------

public class PreciosTests:TestContext
{
    [Fact]
    public void Precios_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 1. SI Precios inyecta ILogger<Precios>, DESCOMENTA esta línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<Precios>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<Precios>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("Encendido y apagado tv o consola o música, también del aire del salón", cut.Markup);
    }
}
