using BlazorServer.Pages;
using Bunit;

namespace BlazorServer.Tests.Components;

// ESTA ES LA PLANTILLA A COPIAR Y ADAPTAR:
// ------------------------------------------

public class InmoticaTests : TestContext
{
    [Fact]
    public void Inmotica_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 1. SI ComponenteX inyecta ILogger<ComponenteX>, DESCOMENTA esta línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<ComponenteX>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<Inmotica>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("La Inmótica integra la domótica interna dentro de una estructura en red", cut.Markup);
    }
}
// ------------------------------------------