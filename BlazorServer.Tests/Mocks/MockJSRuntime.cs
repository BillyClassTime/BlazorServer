using Microsoft.JSInterop;

namespace BlazorServer.Tests.Mocks;
public class MockJSRuntime : IJSRuntime
{
    // Almacenamos los métodos invocados
    public List<(string method, object[] args)> InvokedMethods { get; } = [];

    // Implementación de InvokeAsync<TValue>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        // Guardamos el método y los argumentos invocados para verificar más tarde
        InvokedMethods.Add((identifier, (args ?? Array.Empty<object>()) as object[]));

        // Retornar el tipo por defecto para TValue
        return new ValueTask<TValue>(default(TValue)!);
    }

    // Implementación de InvokeVoidAsync
    public ValueTask InvokeVoidAsync(string identifier, object?[]? args)
    {
        // Guardamos el método y los argumentos invocados para verificar más tarde
        InvokedMethods.Add((identifier, (args ?? []) as object[]));

        // Retorno vacío
        return ValueTask.CompletedTask;
    }

    // Implementación de InvokeAsync con CancellationToken (para completar la interfaz)
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
    {
        // Guardamos el método y los argumentos invocados para verificar más tarde
        InvokedMethods.Add((identifier, (args ?? Array.Empty<object>()) as object[]));

        // Simulamos un retorno vacío para métodos que no devuelven valor
        return new ValueTask<TValue>(default(TValue)!);
    }
}