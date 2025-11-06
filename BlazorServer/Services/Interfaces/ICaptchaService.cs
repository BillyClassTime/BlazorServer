namespace BlazorServer.Services.Interfaces;
public interface ICaptchaService
{
    CaptchaModel Generate();
    bool Validate(string userAnswer, int correctAnswer);
}
