using BlazorServer.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using BlazorServer.Tests.Mocks;

namespace BlazorServer.Tests.Components;

public class PrivatePoliciesFunctionalTests : TestContext
{
    [Fact]
    public void AnchorClicksShouldInvokeJsRuntimeToNavigate()
    {
        TestContext.DefaultWaitTimeout = TimeSpan.FromSeconds(20);

        var jsRuntimeMock = new MockJSRuntime();

        // Arranging the component
        var ctx = new TestContext();

        ctx.Services.AddSingleton<IJSRuntime>(jsRuntimeMock);

        var component = ctx.RenderComponent<PrivatePolicies>();

        component.WaitForState(() => component.FindAll("a[href='#']").Any());

        var anchorIds = new[]
{
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
        };

        // Itera sobre cada ID de ancla para verificar que se invoca correctamente el JavaScript
        foreach (var anchorId in anchorIds)
        {
              var anchorLink = component.Find($"a[href='#'][blazor\\:onclick='{anchorId}']");

            Assert.NotNull( anchorLink );

            anchorLink.Click();

            var invokedMethod = jsRuntimeMock.InvokedMethods.FirstOrDefault(m => m.method == "navigateToAnchor");
            Assert.NotEmpty(invokedMethod.args);
            Assert.Single(invokedMethod.args);
        }
    }

}



