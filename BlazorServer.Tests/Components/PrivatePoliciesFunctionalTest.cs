using BlazorServer.Pages;
using Bunit;

public class PrivatePoliciesFunctionalTests : TestContext
{
    [Theory]
    [InlineData("1. Qué información recogemos", "collect")]
    [InlineData("2. Cómo procesamos tu información", "process")]
    [InlineData("3. Con quién compartimos tu información", "share")]
    [InlineData("9. ¿Cómo contactarnos?", "contact")]
    [InlineData("10. ¿Cómo revisar, actualizar o eliminar tus datos?", "review-update-delete")]
    public void AnchorClicks_ShouldInvokeJsRuntimeToNavigate(string visibleText, string expectedAnchorId)
    {
        // Arrange: renderizar el componente
        var cut = RenderComponent<PrivatePolicies>();

        // Act: localizar el enlace por texto visible
        var elementToClick = cut.FindAll("li.list-group-item a")
                                .FirstOrDefault(e => e.TextContent.Contains(expectedAnchorId));


        Assert.NotNull(elementToClick); // prueba de contenido
        elementToClick.Click();         // dispara el evento

        // Assert: verificar la invocación JS
        var inv = JSInterop.VerifyInvoke("navigateToAnchor");
        Assert.Equal(expectedAnchorId, inv.Arguments[0]?.ToString());
    }
}