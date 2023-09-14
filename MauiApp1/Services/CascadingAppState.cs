namespace MauiApp1.Services
{
    public class CascadingAppState
    {
        public CascadingAppState()
        {
        }

        public async Task ToggleTheme()
        {
            if (OnToggleTheme != null)
            {
                await OnToggleTheme.Invoke();
            }
        }
        public event Func<Task>? OnToggleTheme;
    }
}
