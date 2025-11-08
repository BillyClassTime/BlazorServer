using BlazorServer.Pages;
using Bunit;

namespace BlazorServer.Tests.Components;

public class QuienesSomosTests : TestContext
{
    [Fact]
    public void QuienesSomos_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 1. SI QuienesSomos inyecta ILogger<QuienesSomos>, DESCOMENTA esta línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<QuienesSomos>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<QuienesSomos>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("sean 100% confiables y seguras.", cut.Markup);
    }
}
