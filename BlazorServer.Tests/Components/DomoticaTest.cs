using BlazorServer.Pages;
using Bunit;

namespace BlazorServer.Tests.Components;

public class DomoticaTest : TestContext
{
    public DomoticaTest() { }

    [Fact]
    public void Domotica_ShouldRenderWithoutErrors()
    {
        // 1. ARRANGE: Inicializar el contexto
        using var ctx = new TestContext();

        // 2. ARRANGE: Inyección de Dependencias (solo si el componente las tiene)
        // Ejemplo: Si Domotica.razor inyecta ILogger<Domotica>
        // ctx.Services.AddSingleton(Mock.Of<ILogger<Domotica>>()); 

        // 3. ACT: Renderizar el componente
        // Cambia [NombreComponente] por el nombre de tu componente (ej. Domotica)
        var cut = ctx.RenderComponent<Domotica>();

        // 4. ASSERT: Verifica que renderizó sin lanzar excepciones (Smoke Test)
        Assert.NotNull(cut.Markup);

        // 5. ASSERT: Verificación de contenido (Opcional, pero recomendado)
        // Cambia el texto por una frase clave que solo esté en ese componente.
        Assert.Contains("DOMÓTICA", cut.Markup);
    }
}