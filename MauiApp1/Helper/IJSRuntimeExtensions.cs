using Microsoft.JSInterop;

namespace MauiApp1.Helper;

public static partial class IJSRuntimeExtensions
{
    public static async Task ToggleTheme(this IJSRuntime jsRuntime, string themeName)
    {
        await jsRuntime.InvokeVoidAsync("ToggleTheme", themeName);
    }
}