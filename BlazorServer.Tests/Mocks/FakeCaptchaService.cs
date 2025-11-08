using BlazorServer.Services.Interfaces;
using BlazorServer.Services;

namespace BlazorServer.Tests.Mocks;
public class FakeCaptchaService : ICaptchaService
{
    public CaptchaModel Generate()
    {
        return new CaptchaModel("9-5", 14 );
    }

    public bool Validate(string userAnswer, int correctAnswer)
        => int.TryParse(userAnswer, out var val) && val == correctAnswer;
}


//public class FakeCaptchaService : ICaptchaService
//{
//    public CaptchaModel Generate() => new("", 0);

//    public bool Validate(string userAnswer, int correctAnswer) => true;
//}
