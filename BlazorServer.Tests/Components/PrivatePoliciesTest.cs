using BlazorServer.Pages;
using Bunit;

namespace BlazorServer.Tests.Components;

public class PrivatePoliciesTests : TestContext
{
    [Fact]
    public void PrivatePolicies_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // 1. SI PrivatePolicies inyecta ILogger<PrivatePolicies>, DESCOMENTA esta línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<PrivatePolicies>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<PrivatePolicies>();

        // 3. ASSERT: Verifica que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);

        // 4. ASSERT: Verificación de contenido para asegurar que es la página correcta.
        Assert.Contains("Puedes solicitar acceso, actualización o eliminación de tu información personal", cut.Markup);
    }
}
