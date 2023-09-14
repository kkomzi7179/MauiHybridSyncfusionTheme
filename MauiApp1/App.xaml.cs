using MauiApp1.ViewModel;

using Syncfusion.Licensing;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            // todo : Register Syncfusion license
            SyncfusionLicenseProvider.RegisterLicense("");

            InitializeComponent();

            MainPage = new HybridPage();

            Application.Current.RequestedThemeChanged += async (s, e) =>
            {
                await UpdateAppShellInfo();
            };
        }
        async Task UpdateAppShellInfo()
        {
            var page = Application.Current.MainPage as HybridPage;
            if (page is not null)
            {
                var vm = page.BindingContext as HybridPageViewModel;
                if (vm is not null)
                {
                    await vm.UpdateAppShellInfo();
                }
            }
        }
    }
}