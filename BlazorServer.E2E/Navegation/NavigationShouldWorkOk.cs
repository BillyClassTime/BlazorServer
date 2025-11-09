using System.Text;
using System.Globalization;
using Xunit;

namespace BlazorServer.E2E.Navegation;
public partial class PlaywrightTests
{
    [Fact]
    public async Task Navigation_ShouldWorkCorrectly_BetweenSections()
    {
        // Función para eliminar diacríticos (tildes) y normalizar texto
        string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC).Trim();
        }

        // Navegar a la página principal
        await _page.GotoAsync("http://localhost:5000");

        // Obtener el título de la página y normalizar
        var pageTitle = await _page.TitleAsync();
        var normalizedExpected = RemoveDiacritics("Domótica Brotons"); // texto esperado con tilde
        var normalizedActual = RemoveDiacritics(pageTitle);

        Console.WriteLine("Expected: " + normalizedExpected);
        Console.WriteLine("Actual: " + normalizedActual);

        // Comparación ignorando mayúsculas/minúsculas y tildes
        Assert.Equal(normalizedExpected, normalizedActual, StringComparer.OrdinalIgnoreCase);

        // --- Navegación a la sección "Servicios" ---
        var serviciosLink = await _page.QuerySelectorAsync("text=servicios");
        await serviciosLink!.ClickAsync();

        var serviciosSection = await _page.QuerySelectorAsync("#servicios");
        Assert.NotNull(serviciosSection);

        var serviciosText = await serviciosSection.InnerTextAsync();
        Assert.Contains("Una casa inteligente", serviciosText);

        // --- Navegación a la sección "Domótica" ---
        var domoticaLink = await _page.QuerySelectorAsync("text=domotica");
        await domoticaLink!.ClickAsync();

        var domoticaSection = await _page.QuerySelectorAsync("#domotica");
        Assert.NotNull(domoticaSection);

        var domoticaText = await domoticaSection.InnerTextAsync();
        Assert.Contains("es el conjunto de sistemas", domoticaText);
    }
}
