using Microsoft.Extensions.Logging.Abstractions;
using System.Data.SqlTypes;

namespace MauiAppNSRI;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        bool isRegistered = await RegisterUserAsync(
            NameEntry.Text,
            SurnameEntry.Text,
            UsernameEntry.Text,
            PasswordEntry.Text,
            DobEntry.Text,
            IdEntry.Text
        );

        if (isRegistered)
        {
            await DisplayAlert("Registration Successful", "You can now log in with your credentials.", "OK");
            await Shell.Current.GoToAsync("//LoginPage");
        }
        else
        {
            await DisplayAlert("Registration Failed", "There was an error during registration. Please try again.", "OK");
        }
    }

    private Task<bool> RegisterUserAsync(string name, string surname, string username, string password, string dob, string id)
    {
        // Placeholder for actual registration logic
        return Task.FromResult(!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password));
    }
}
