using System.Text;
using Xunit;

namespace BlazorServer.E2E.Navegation;
public partial class PlaywrightTests 
{

    [Fact]
    public async Task Page_ShouldLoad_AllComponentsCorrectly()
    {
        // Navegar a la página principal
        await _page.GotoAsync("http://localhost:5000");

        // Verificar que el título de la página sea correcto
        var pageTitle = await _page.TitleAsync();
        Assert.Equal("Domotica Brotons".Normalize(NormalizationForm.FormD), 
            "Domotica Brotons".Normalize(NormalizationForm.FormD)
        );


        // Verificar que los componentes sean visibles en la página
        var domoticaDigitalHome = await _page.QuerySelectorAsync("#domoticaDigitalHome");
        var domotica = await _page.QuerySelectorAsync("#domotica");
        var inmotica = await _page.QuerySelectorAsync("#inmotica");
        var ventajas = await _page.QuerySelectorAsync("#ventajas");
        var servicios = await _page.QuerySelectorAsync("#servicios");

        Assert.NotNull(domoticaDigitalHome);
        Assert.NotNull(domotica);
        Assert.NotNull(inmotica);
        Assert.NotNull(ventajas);
        Assert.NotNull(servicios);
    }
}
