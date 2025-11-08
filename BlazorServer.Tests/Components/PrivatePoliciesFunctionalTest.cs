using BlazorServer.Pages;
using Bunit;
using Xunit;

namespace BlazorServer.Tests.Components;

public class PrivatePoliciesFunctionalTests : TestContext
{
    [Theory]
    [InlineData("collect")]
    [InlineData("process")]
    [InlineData("share")]
    [InlineData("contact")]
    [InlineData("review-update-delete")]
    public void AnchorClicks_ShouldInvokeJsRuntimeToNavigate(string expectedAnchorId)
    {
        // ARRANGE: configurar JSInterop para aceptar la llamada
        JSInterop.SetupVoid("navigateToAnchor", _ => true);

        var cut = RenderComponent<PrivatePolicies>();

        // ACT: buscar el enlace por el id esperado
        var elementToClick = cut.Find($"a[href='#{expectedAnchorId}']");
        elementToClick.Click();

        // ASSERT: verificar que se invocó JSInterop con el id correcto
        var inv = JSInterop.VerifyInvoke("navigateToAnchor");
        Assert.Equal(expectedAnchorId, inv.Arguments[0]?.ToString());
    }
}