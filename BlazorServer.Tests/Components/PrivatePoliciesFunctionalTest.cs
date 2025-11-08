using BlazorServer.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BlazorServer.Tests.Components;

public class PrivatePoliciesFunctionalTests : TestContext
{
    [Fact]
    public void AnchorClicksShouldInvokeJsRuntimeToNavigate()
    {
        TestContext.DefaultWaitTimeout = TimeSpan.FromSeconds(20);

        //var jsRuntimeMock = new Mock<IJSRuntime>();
        var jsRuntimeMock = new MockJSRuntime();

        // Arranging the component
        var ctx = new TestContext();

        //ctx.Services.AddSingleton(jsRuntimeMock.Object);
        ctx.Services.AddSingleton<IJSRuntime>(jsRuntimeMock);

        var component = ctx.RenderComponent<PrivatePolicies>();

        //component.WaitForElement("a[href='#'][blazor\\:onclick='collect']");
        component.WaitForState(() => component.FindAll("a[href='#']").Any());

        Console.WriteLine($"ESTE ES EL COMPONENTE:\n{component.Markup}");
        // Listado de IDs de los anclajes a probar
        /*var anchorIds = new[]
        {
        "collect", "process", "share", "retention", "security", "minors", "rights", "updates", "contact", "review-update-delete"
        };*/
        var anchorIds = new[]
{
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
        };


        // Itera sobre cada ID de ancla para verificar que se invoca correctamente el JavaScript
        foreach (var anchorId in anchorIds)
        {
            //var anchorLink = component.Find($"a[href='#'{anchorId}']");
            //var anchorLink = component.Find($"a[href='#{anchorId}']");
            //var anchorLink = component.Find($"a[href='#'][blazor\\:onclick='{anchorId}']");
            //var dobleComilla = "\"\"";
            //var anchorLink = component.Find($"a[href={dobleComilla}#{dobleComilla}][blazor\\:onclick={dobleComilla}{anchorId}{dobleComilla}]");
            //var anchorLink = component.Find($"a[href='#'][blazor\\:onclick='{anchorId}']");
              var anchorLink = component.Find($"a[href='#'][blazor\\:onclick='{anchorId}']");

            Assert.NotNull( anchorLink );

            // Asegúrate de que cada ancla tiene un `onclick` que llama a `NavigateToAnchor()`
            anchorLink.Click();

            // Verifica que se ha invocado el método correspondiente en JsRuntime
            //var expectedCall = $"navigateToAnchor('{anchorId}')";

            //jsRuntimeMock.Verify(j => j.InvokeVoidAsync("navigateToAnchor", anchorId), Times.Once);
            /*jsRuntimeMock.Verify(
                  j => j.InvokeVoidAsync(It.IsAny<string>(), It.IsAny<object[]>()),
                  Times.Once
            );*/
            /*jsRuntimeMock.Verify(
                js => js.InvokeVoidAsync("navigateToAnchor", It.Is<object[]>(o => o != null)),
                Times.Once
            );*/

            //var (method, args) = jsRuntimeMock.InvokedMethods.FirstOrDefault(m => m.method == "navigateToAnchor");
            var invokedMethod = jsRuntimeMock.InvokedMethods.FirstOrDefault(m => m.method == "navigateToAnchor");
            Assert.NotEmpty(invokedMethod.args);
            Assert.Single(invokedMethod.args);
        }
    }

}

public class MockJSRuntime : IJSRuntime
{
    public List<(string method, object[] args)> InvokedMethods { get; } = new List<(string method, object[] args)>();

    public ValueTask<TValue> InvokeAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string identifier, object?[]? args)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TValue> InvokeAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
    {
        throw new NotImplementedException();
    }

    public Task InvokeVoidAsync(string identifier, object[] args)
    {
        // Capturamos las llamadas al método
        InvokedMethods.Add((identifier, args));
        return Task.CompletedTask;  // Simula la respuesta de InvokeVoidAsync
    }

}

