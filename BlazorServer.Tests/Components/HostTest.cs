using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BlazorServer.Infrastructure.Interfaces;
using BlazorServer.Services.Interfaces;
using BlazorServer.Tests.Mocks;

namespace BlazorServer.Tests.Components;
public class HostIntegrationTests : TestContext
{
    public HostIntegrationTests()
    {
        // ARRANGE: Configurar inyecciones necesarias para componentes compartidos.
        var config = new ConfigurationBuilder().Build();
        Services.AddSingleton<IConfiguration>(config);
        Services.AddSingleton<IAppVersionInfo>(new FakeAppVersionInfo());
        Services.AddScoped<IEmailGraphService,FakeEmailGraphService>();
        Services.AddSingleton<ICaptchaService>(new FakeCaptchaService());
    }

    [Fact]
    public void HostPage_ShouldRenderAppRootComponent()
    {
        // ARRANGE: 
        var inv = JSInterop.SetupVoid("navbarShrink", args => true);

        // ACT: Renderiza el componente raíz de la aplicación (<App>).
        var cut = RenderComponent<App>();

        // ASSERT: Verificamos que se renderizó el markup correctamente sin lanzar excepciones.
        Assert.NotNull(cut.Markup);

        // ASSERT: 
        Assert.NotNull(inv);

        // Verificar un contenido conocido del layout para asegurar que cargó la App completa.
        Assert.Contains("Usamos cookies", cut.Markup);
    }
}



