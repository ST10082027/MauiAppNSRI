using System;
using System.IO;
using Microsoft.Maui.Storage;
using SQLite;

namespace MauiAppNSRI
{
    /// <summary>
    /// RegistrationPage manages user registration, including data validation, 
    /// file uploads for ID images, and database storage of user data.
    /// </summary>
    public partial class RegistrationPage : ContentPage
    {
        private FileResult frontIdImage;
        private FileResult backIdImage;
        private readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "user_database.db3");

        public RegistrationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the registration process, validates fields, and saves user data to the database.
        /// </summary>
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            if (!ValidateRegistrationFields())
                return;

            // Format Name and Surname
            string formattedName = CapitalizeFirstLetter(NameEntry.Text);
            string formattedSurname = CapitalizeFirstLetter(SurnameEntry.Text);

            // Format Email
            string formattedEmail = EmailEntry.Text.Trim().ToLower();

            var user = new UserModel
            {
                Username = UsernameEntry.Text.Trim(),
                Password = PasswordEntry.Text,
                Name = formattedName,
                Surname = formattedSurname,
                DateOfBirth = DateOfBirthEntry.Date,
                IDNumber = IDNumberEntry.Text.Trim(),
                Email = formattedEmail,
                CellphoneNumber = CellphoneEntry.Text.Trim(),
                FrontIdImagePath = frontIdImage?.FullPath,
                BackIdImagePath = backIdImage?.FullPath
            };

            // Insert user data into SQLite database
            using var db = new SQLiteConnection(dbPath);
            db.CreateTable<UserModel>();
            db.Insert(user);

            await DisplayAlert("Success", "Registration successful! Redirecting to login.", "OK");
            ClearFields();
            await Shell.Current.GoToAsync("//LoginPage");
        }

        /// <summary>
        /// Capitalizes the first letter of a given text string.
        /// </summary>
        private string CapitalizeFirstLetter(string text) =>
            string.IsNullOrWhiteSpace(text) ? string.Empty : char.ToUpper(text[0]) + text.Substring(1).ToLower();

        /// <summary>
        /// Clears all input fields after registration is completed.
        /// </summary>
        private void ClearFields()
        {
            UsernameEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
            NameEntry.Text = string.Empty;
            SurnameEntry.Text = string.Empty;
            DateOfBirthEntry.Date = DateTime.Now;
            IDNumberEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            CellphoneEntry.Text = string.Empty;
            frontIdImage = null;
            backIdImage = null;
        }

        /// <summary>
        /// Validates required fields and ID image uploads.
        /// </summary>
        private bool ValidateRegistrationFields()
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(SurnameEntry.Text) ||
                string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
                string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
                DateOfBirthEntry.Date == default ||
                string.IsNullOrWhiteSpace(IDNumberEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                !EmailEntry.Text.Contains("@") ||
                string.IsNullOrWhiteSpace(CellphoneEntry.Text) ||
                frontIdImage == null || backIdImage == null)
            {
                DisplayAlert("Validation Error", "All fields must be completed, valid, and ID images uploaded.", "OK");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Initiates file picker for selecting the front ID image.
        /// </summary>
        private async void OnFrontIdUploadClicked(object sender, EventArgs e)
        {
            frontIdImage = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select the front of your ID",
                FileTypes = FilePickerFileType.Images
            });
            if (frontIdImage == null)
                await DisplayAlert("Error", "Front ID image selection failed.", "OK");
        }

        /// <summary>
        /// Initiates file picker for selecting the back ID image.
        /// </summary>
        private async void OnBackIdUploadClicked(object sender, EventArgs e)
        {
            backIdImage = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select the back of your ID",
                FileTypes = FilePickerFileType.Images
            });
            if (backIdImage == null)
                await DisplayAlert("Error", "Back ID image selection failed.", "OK");
        }

        // Method to navigate to LoginPage when link is tapped
        private async void OnLoginLinkTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

/// <summary>
/// UserModel represents the data structure for storing user details in the local SQLite database.
/// </summary>
public class UserModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string IDNumber { get; set; }
    public string Email { get; set; }
    public string CellphoneNumber { get; set; }
    public string FrontIdImagePath { get; set; }
    public string BackIdImagePath { get; set; }
}

