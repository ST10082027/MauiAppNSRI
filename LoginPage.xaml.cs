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
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Please enter both Username and Password.", "OK");
                return;
            }

            using var db = new SQLiteConnection(dbPath);
            db.CreateTable<UserModel>();

            var user = db.Table<UserModel>().FirstOrDefault(u => u.Username == UsernameEntry.Text && u.Password == PasswordEntry.Text);

            if (user != null)
            {
                // Store the logged-in user's information
                Preferences.Set("LoggedInUsername", user.Username);
                Preferences.Set("UserRole", user.Role);  // Store role for access control
                await DisplayAlert("Success", $"Welcome, {user.Username}!", "OK");
                await Shell.Current.GoToAsync("//MainPage");// Navigate to the main page
                UsernameEntry.Text = string.Empty; // Clear the username field
                PasswordEntry.Text = string.Empty;  // Clear the password field
            }
            else
            {
                await DisplayAlert("Authentication Failed", "Invalid username or password.", "OK");
                PasswordEntry.Text = string.Empty; // Clear the password field on failed login
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
