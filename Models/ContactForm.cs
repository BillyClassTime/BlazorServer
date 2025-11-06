using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models;

public class FormDataModel
{
    [Required] public string? Name { get; set; }
    [Required, EmailAddress] public string? Email { get; set; }
    [Required] public string? Phone { get; set; }
    [Required] public string? Message { get; set; }

    // Captcha
    public string CaptchaQuestion { get; set; } = "";
    public int CaptchaAnswer { get; set; }
    public string UserAnswer { get; set; } = "";
}