using MyMauiApp.Views;

namespace MyMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Add Routing - needed for page navigation
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}