using MauiApp1.Helper;
using MauiApp1.Services;
using MauiApp1.ViewModel;

namespace MauiApp1
{
    public partial class HybridPage : ContentPage
    {
        public HybridPageViewModel VM { get; set; }
        public HybridPage()
        {
            VM = ServiceHelper.GetService<HybridPageViewModel>();

            InitializeComponent();
        }
    }
}