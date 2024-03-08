using MyApp.Views;

namespace MyApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Add Routing - needed for page navigation
            Routing.RegisterRoute(nameof(ArticleDetailPage), typeof(ArticleDetailPage));
            Routing.RegisterRoute(nameof(PodcastDetailPage), typeof(PodcastDetailPage));
        }
    }
}
