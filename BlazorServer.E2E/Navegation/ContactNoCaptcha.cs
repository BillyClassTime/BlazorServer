using Microsoft.Playwright;
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
        var nameInput = await _page.QuerySelectorAsync("input[name='formData.Name']");
        var emailInput = await _page.QuerySelectorAsync("input[name='formData.Email']");
        var messageInput = await _page.QuerySelectorAsync("textarea[name='formData.Message']");

        // Esperar a que los elementos estén disponibles
        Assert.NotNull(nameInput);
        Assert.NotNull(emailInput);
        Assert.NotNull(messageInput);

        // Esperar a que los campos sean visibles y habilitados
        await nameInput.WaitForElementStateAsync(ElementState.Visible);

        // Llenar los campos
        await nameInput.FillAsync("John Doe");
        await emailInput.FillAsync("john.doe@example.com");
        await messageInput.FillAsync("Hello, this is a test message.");

        // Completar el captcha con una respuesta incorrecta
        var captchaInput = await _page.QuerySelectorAsync("input.form-control.bg-dark");
        Assert.NotNull(captchaInput);
        await captchaInput.FillAsync("2");  // Respuesta incorrecta al captcha

        // Intentar enviar el formulario
        var submitButton = await _page.QuerySelectorAsync("button[type='submit']");
        await submitButton!.ClickAsync();

        // Esperar y verificar el mensaje de error relacionado con el captcha
        await _page.WaitForSelectorAsync("div.form-text.text-light");
        var captchaErrorMessage = await _page.QuerySelectorAsync("div.form-text.text-light");
        Assert.NotNull(captchaErrorMessage);

        // Verificar que el mensaje contiene la advertencia correcta
        var errorMessage = await captchaErrorMessage.InnerTextAsync();
        Assert.Contains("Resuelve la operación para confirmar que no eres un bot", errorMessage);
    }
}