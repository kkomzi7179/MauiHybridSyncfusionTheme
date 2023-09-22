using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MauiApp1.Services;

namespace MauiApp1.ViewModel
{
    public partial class HybridPageViewModel : ObservableObject
    {
        readonly CascadingAppState _cascadingAppState;
        public HybridPageViewModel(CascadingAppState cascadingAppState)
        {
            _cascadingAppState = cascadingAppState;
        }
        public string ThemeInfo
        {
            get { return $"System : {Application.Current?.PlatformAppTheme}, App : {Application.Current?.UserAppTheme}"; }
        }
        public bool IsDefault
        {
            get { return Application.Current?.UserAppTheme == AppTheme.Unspecified; }
        }
        public bool IsDark
        {
            get { return Application.Current?.UserAppTheme == AppTheme.Dark; }
        }
        public bool IsLight
        {
            get { return Application.Current?.UserAppTheme == AppTheme.Light; }
        }
        [RelayCommand]
        async Task Theme(object? parameter)
        {
            
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                AppTheme? appTheme = (AppTheme)Enum.Parse(typeof(AppTheme), parameter.ToString());
                if (appTheme is not null && Application.Current is not null)
                {
                    Application.Current.UserAppTheme = appTheme.Value;
                    await _cascadingAppState.ToggleTheme();
                }
            });
        }
        public async Task UpdateAppShellInfo()
        {
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                OnPropertyChanged(nameof(ThemeInfo));
                OnPropertyChanged(nameof(IsDefault));
                OnPropertyChanged(nameof(IsDark));
                OnPropertyChanged(nameof(IsLight));
            });
        }
    }
}
