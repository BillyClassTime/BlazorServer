using BlazorServer.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel;
using Xunit;

namespace BlazorServer.Tests.Components;

public class TermTests : TestContext
{
    [Fact]
    public void Term_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 1. SI Term inyecta ILogger<Term>, DESCOMENTA esta línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<Term>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<Term>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("Te recomendamos revisarlos periódicamente", cut.Markup);
    }
}
