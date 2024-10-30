namespace MauiAppNSRI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set MainPage to AppShell and navigate to HomePage
            MainPage = new AppShell();
          
        }
    }
}

