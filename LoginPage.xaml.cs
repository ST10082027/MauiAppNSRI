namespace MauiAppNSRI;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        // Initialize components defined in XAML file
        InitializeComponent();
    }

    /// <summary>
    /// Handles the login button click event.
    /// Authenticates the user with provided credentials and navigates to MainPage if successful.
    /// </summary>
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Authenticate the user using the provided username and password
        bool isAuthenticated = await AuthenticateUserAsync(UsernameEntry.Text, PasswordEntry.Text);

        if (isAuthenticated)
        {
            // Navigate to the MainPage upon successful authentication
            await Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            // Display an alert message for authentication failure
            await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
        }
    }

    /// <summary>
    /// Handles the tap gesture event on the "Register here" link.
    /// Navigates the user to the RegistrationPage to create a new account.
    /// </summary>
    private async void OnRegisterLinkTapped(object sender, EventArgs e)
    {
        // Navigate to the RegistrationPage using the defined route
        await Shell.Current.GoToAsync("//RegistrationPage");
    }

    /// <summary>
    /// Simulates user authentication logic for demonstration purposes.
    /// This method would normally interface with a backend or database for real authentication.
    /// </summary>
    /// <param name="username">The entered username.</param>
    /// <param name="password">The entered password.</param>
    /// <returns>A Task that resolves to true if the user is authenticated, false otherwise.</returns>
    private static Task<bool> AuthenticateUserAsync(string username, string password)
    {
        // Placeholder authentication logic; replace with actual logic as needed
        return Task.FromResult(username == "testuser" && password == "password123");
    }
}
