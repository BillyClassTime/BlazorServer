using System.Text;
using Xunit;

namespace BlazorServer.E2E.Navegation;
public partial class PlaywrightTests 
{
    [Fact]
    public async Task Navigation_ShouldWorkCorrectly_BetweenSections()
    {
        // Navegar a la página principal
        await _page.GotoAsync("http://localhost:5000");

        // Verificar que la página se carga correctamente
        var pageTitle = await _page.TitleAsync();
        var normalizedExpected = "Domotica Brotons".Normalize(NormalizationForm.FormD).Trim();
        var normalizedActual = pageTitle.Normalize(NormalizationForm.FormD).Trim();

        Console.WriteLine("Expected: " + normalizedExpected);
        Console.WriteLine("Actual: " + normalizedActual);

        Assert.Equal(normalizedExpected, normalizedActual, StringComparer.OrdinalIgnoreCase);


        // Navegar a la sección "Servicios"
        var serviciosLink = await _page.QuerySelectorAsync("text=servicios");
        await serviciosLink!.ClickAsync();

        // Esperar a que la sección "Servicios" se cargue
        var serviciosSection = await _page.QuerySelectorAsync("#servicios");// Suponiendo que la sección tiene un ID "ervicios"
        Assert.NotNull(serviciosSection);

        // Verificar que el contenido de la sección "Servicios" esté visible
        var serviciosText = await serviciosSection.InnerTextAsync();
        Assert.Contains("Una casa inteligente", serviciosText);               // Ajusta el texto según lo que aparece en esa sección

        // Ahora verificar la navegación a la siguiente sección, por ejemplo, "Domótica"
        var domoticaLink = await _page.QuerySelectorAsync("text=domotica");
        await domoticaLink!.ClickAsync();

        // Esperar a que la sección "Domótica" se cargue
        var domoticaSection = await _page.QuerySelectorAsync("#domotica");  // Suponiendo que la sección tiene un ID "Domotica"
        Assert.NotNull(domoticaSection);

        // Verificar que el contenido de la sección "Domótica" esté visible
        var domoticaText = await domoticaSection.InnerTextAsync();
        Assert.Contains("es el conjunto de sistemas", domoticaText);            // Ajusta el texto según lo que aparece en esa sección
    }

}
