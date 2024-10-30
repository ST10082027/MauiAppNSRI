namespace MauiAppNSRI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public Command GoToProfileCommand => new Command(async () => await Shell.Current.GoToAsync("//ProfilePage"));
        public Command GoToSettingsCommand => new Command(async () => await Shell.Current.GoToAsync("//SettingsPage"));
        public Command GoToSessionsCommand => new Command(async () => await Shell.Current.GoToAsync("//SessionsPage"));
    }
}
