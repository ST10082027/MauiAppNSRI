namespace MauiAppNSRI;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object _, EventArgs _1)
    {
        // Placeholder for login authentication
        bool isAuthenticated = await AuthenticateUserAsync(UsernameEntry.Text, PasswordEntry.Text);
        if (isAuthenticated)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid credentials.", "OK");
        }
    }

    private static Task<bool> AuthenticateUserAsync(string username, string password)
    {
        return Task.FromResult(username == "testuser" && password == "password123");
    }
}
