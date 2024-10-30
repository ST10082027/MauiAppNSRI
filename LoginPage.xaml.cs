using System;
using System.Threading.Tasks;

namespace MauiAppNSRI
{
    public partial class LoginPage : ContentPage
    {
        private static readonly string[] Scopes = { "User.Read" };

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var authResult = await App.SignInAsync(Scopes);
            if (authResult != null)
            {
                await DisplayAlert("Success", $"Welcome {authResult.Account.Username}", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await DisplayAlert("Error", "Authentication failed", "OK");
            }
        }

        private async void OnRegisterLinkTapped(object sender, EventArgs e)
        {
            // Navigate to the registration page
            await Shell.Current.GoToAsync("//RegistrationPage");
        }
    }
}
