using BlazorServer.Pages;
using Bunit;
using Microsoft.Graph.Models;

namespace BlazorServer.Tests.Components;

public class EsquemaContratacionTests : TextContent
{
    [Fact]
    public void EsquemaContratacion_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<EsquemaContratacion>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("De esta forma puede estar tranquilo de", cut.Markup);
    }
}