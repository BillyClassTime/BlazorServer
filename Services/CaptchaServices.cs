using BlazorServer.Services.Interfaces;
namespace BlazorServer.Services;

public class CaptchaService : ICaptchaService
{
    public CaptchaModel Generate()
    {
        var rnd = new Random();
        var a = rnd.Next(2, 9);
        var b = rnd.Next(2, 9);
        var op = rnd.Next(0, 2);

        string question;
        int answer;

        if (op == 0)
        {
            question = $"¿Cuánto es {a} + {b}?";
            answer = a + b;
        }
        else
        {
            if (a < b) (a, b) = (b, a);
            question = $"¿Cuánto es {a} - {b}?";
            answer = a - b;
        }

        return new CaptchaModel(question, answer);
    }

    public bool Validate(string userAnswer, int correctAnswer)
        => int.TryParse(userAnswer, out var val) && val == correctAnswer;
}

public record CaptchaModel(string Question, int Answer);