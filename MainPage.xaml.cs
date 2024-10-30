namespace MauiAppNSRI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Navigates to ProfilePage on button click
        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ProfilePage");
        }

        // Navigates to SettingsPage on button click
        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SettingsPage");
        }

        // Navigates to SessionsPage on button click
        private async void OnSessionsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SessionsPage");
        }
    }
}