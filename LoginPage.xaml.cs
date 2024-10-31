using System;
using System.IO;
using SQLite;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace MauiAppNSRI
{
    /// <summary>
    /// LoginPage manages the user login functionality,
    /// verifies credentials, and navigates upon successful login.
    /// </summary>
    public partial class LoginPage : ContentPage
    {
        // Database path for storing user data in a SQLite database
        private readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "user_database.db3");

        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the login button click event, validates input fields,
        /// authenticates the user, and navigates to MainPage on success.
        /// </summary>
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Validate that both username and password fields are populated
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Please enter both Username and Password.", "OK");
                return;
            }

            // Establish a connection to the SQLite database and create the user table if not existing
            using var db = new SQLiteConnection(dbPath);
            db.CreateTable<UserModel>();

            // Query for a user matching the entered username and password
            var user = db.Table<UserModel>().FirstOrDefault(u => u.Username == UsernameEntry.Text && u.Password == PasswordEntry.Text);

            if (user != null)
            {
                Preferences.Set("LoggedInUsername", user.Username);
                var storedUsername = Preferences.Get("LoggedInUsername", string.Empty);
                await DisplayAlert("Success", $"Logged in as {storedUsername}", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                // Display error message if authentication fails
                await DisplayAlert("Authentication Failed", "Invalid username or password.", "OK");
            }
        }

        /// <summary>
        /// Handles tap event for the registration link,
        /// navigating the user to the RegistrationPage.
        /// </summary>
        private async void OnRegisterLinkTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegistrationPage");
        }
    }
}
