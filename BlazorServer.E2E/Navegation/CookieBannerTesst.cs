using Microsoft.Playwright;
using Xunit;

namespace BlazorServer.E2E.Navegation;

public partial class PlaywrightTests 
{
    private readonly IPage _page;
    private readonly IBrowser _browser;

    public PlaywrightTests()
    {
        // Setup Playwright
        var playwright = Playwright.CreateAsync().Result;
        _browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true }).Result;
        _page = _browser.NewPageAsync().Result;
    }

    [Fact]
    public async Task CookieBanner_ShouldBeVisible_WhenPageLoads()
    {
        // Navegar a la página principal
        await _page.GotoAsync("http://localhost:5000");

        // Verificar que el banner de cookies esté presente
        var cookiesBanner = await _page.QuerySelectorAsync(".alert.alert-dark");
        Xunit.Assert.NotNull(cookiesBanner); // El banner debe estar presente en la página

        // Verificar que el banner sea visible
        var isVisible = await cookiesBanner.IsVisibleAsync();
        Xunit.Assert.True(isVisible); // El banner debería ser visible al cargar la página
    }

}
