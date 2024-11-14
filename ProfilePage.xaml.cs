using System;
using System.IO;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using SQLite;

namespace MauiAppNSRI
{
    /// <summary>
    /// ProfilePage displays user profile information and provides options to log out,
    /// navigate back, change the profile picture, password, or contact support.
    /// </summary>
    public partial class ProfilePage : ContentPage
    {
        // Path to the SQLite database storing user data
        private readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "user_database.db3");

        public ProfilePage()
        {
            InitializeComponent();
            LoadUserData(); // Load the logged-in user’s data on initialization
        }

        /// <summary>
        /// Loads user data from the database based on the logged-in username.
        /// </summary>
        private void LoadUserData()
        {
            string loggedInUsername = Preferences.Get("LoggedInUsername", string.Empty);

            if (string.IsNullOrEmpty(loggedInUsername))
            {
                DisplayAlert("Error", "No user is logged in.", "OK");
                return;
            }

            using var db = new SQLiteConnection(dbPath);
            db.CreateTable<UserModel>();// Ensure the UserModel table exists

            // Retrieve the logged-in user's details based on the stored username
            var user = db.Table<UserModel>().FirstOrDefault(u => u.Username == loggedInUsername);

            if (user != null)
            {
                // Populate the labels on the profile page with user information
                UsernameLabel.Text = user.Username;
                EmailLabel.Text = user.Email;
                CellphoneLabel.Text = user.CellphoneNumber;

                // Optional additional fields if available in the UserModel
                NameLabel.Text = user.Name;
                SurnameLabel.Text = user.Surname;
                DateOfBirthLabel.Text = user.DateOfBirth.ToString("d");  // Format date if it's nullable
                IDNumberLabel.Text = user.IDNumber;
            }
            else
            {
                DisplayAlert("Error", "User data could not be loaded.", "OK");
            }
        }

        /// <summary>
        /// Logs the user out by removing their username from preferences and redirects to LoginPage.
        /// </summary>
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Clear all stored preferences related to the user session
            Preferences.Remove("LoggedInUsername");
            Preferences.Remove("UserRole");

            // Reset any in-app data that may have been user-specific (optional)
            ClearUserData();

            // Navigate to the login page and clear the navigation stack to prevent "Back" navigation
            await Shell.Current.GoToAsync("//LoginPage");
        }


        /// <summary>
        /// Navigates back to the MainPage.
        /// </summary>
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        /// <summary>
        /// Initiates profile picture change.
        /// </summary>
        private async void OnChangeProfilePictureClicked(object sender, EventArgs e)
        {
            // Logic to change profile picture
        }

        /// <summary>
        /// Initiates password change process.
        /// </summary>
        private async void OnChangePasswordClicked(object sender, EventArgs e)
        {
            // Logic to change password
        }

        /// <summary>
        /// Opens support contact options.
        /// </summary>
        private async void OnContactSupportClicked(object sender, EventArgs e)
        {
            // Logic to contact support
        }

        /// <summary>
        /// Clear profile page labels
        /// </summary>
        public void ClearUserData()
        {
            UsernameLabel.Text = string.Empty;
            EmailLabel.Text = string.Empty;
            CellphoneLabel.Text = string.Empty;
            NameLabel.Text = string.Empty;
            SurnameLabel.Text = string.Empty;
            DateOfBirthLabel.Text = string.Empty;
            IDNumberLabel.Text = string.Empty;
            //RoleLabel.Text = string.Empty;
            //FrontIdImagePathLabel.Text = string.Empty;
            //BackIdImagePathLabel.Text = string.Empty;
        }

    }
}
