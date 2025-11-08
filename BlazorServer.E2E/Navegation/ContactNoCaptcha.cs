using Xunit;

namespace BlazorServer.E2E.Navegation;
public partial class PlaywrightTests 
{
    [Fact]
    public async Task ContactForm_ShouldNotSend_WhenCaptchaNotCompleted()
    {
        // Navegar a la página principal
        await _page.GotoAsync("http://localhost:5000");

        // Completar los campos del formulario (sin resolver el captcha)
        var nameInput = await _page.QuerySelectorAsync("input[name='name']");
        var emailInput = await _page.QuerySelectorAsync("input[name='email']");
        var messageInput = await _page.QuerySelectorAsync("textarea[name='message']");

        await nameInput!.FillAsync("John Doe");
        await emailInput!.FillAsync("john.doe@example.com");
        await messageInput!.FillAsync("Hello, this is a test message.");

        // Intentar enviar el formulario sin resolver el captcha
        var submitButton = await _page.QuerySelectorAsync("button[type='submit']");
        await submitButton!.ClickAsync();

        // Esperar y verificar el mensaje de error relacionado con el captcha
        await _page.WaitForSelectorAsync("div.captcha-error");
        var captchaErrorMessage = await _page.QuerySelectorAsync("div.captcha-error");
        Assert.NotNull(captchaErrorMessage);

        // Verificar el mensaje de error en castellano
        var errorMessage = await captchaErrorMessage.InnerTextAsync();
        Assert.Contains("Captcha incorrecto. Inténtalo de nuevo.", errorMessage);
    }

}