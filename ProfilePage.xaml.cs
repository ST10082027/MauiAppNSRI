using System.Xml;

namespace MauiAppNSRI;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        LoadUserProfile();
    }

    // Command for Back Navigation to MainPage
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Approach 1: Standard Navigation without Shell
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync();
        }
        // Approach 2: Shell-based Navigation if using Shell.Current
        else
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }

    /// <summary>
    /// Loads the user’s profile information and settings when the page initializes.
    /// </summary>
    private void LoadUserProfile()
    {
        // Example data for demonstration. Replace with actual user data retrieval.
        // Set user’s basic information
        NameLabel.Text = "John Doe";
        EmailLabel.Text = "johndoe@example.com";
        PhoneLabel.Text = "+1 234 567 8901";
        UsernameLabel.Text = "john.doe";
        NsriIdLabel.Text = "NSRI12345";

        // Set professional information
        CertificationsLabel.Text = "Lifesaving Certificate - Exp. 2025";
        ExperienceLabel.Text = "5 years";
        ExpertiseLabel.Text = "Survival Swimming, First Aid";

        // Set activity summary
        TotalSessionsLabel.Text = "52";
        RecentSessionsLabel.Text = "01/11/2023 - Community Pool - 5 Participants\n" +
                                   "28/10/2023 - Beachfront - 8 Participants";
    }

    /// <summary>
    /// Handler for changing the profile picture.
    /// </summary>
    private async void OnChangeProfilePictureClicked(object sender, EventArgs e)
    {
        // Placeholder for changing the profile picture
        await DisplayAlert("Profile Picture", "Change profile picture feature coming soon.", "OK");
    }

    /// <summary>
    /// Handler for changing the password.
    /// </summary>
    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        // Placeholder for changing password
        await DisplayAlert("Change Password", "Password change feature coming soon.", "OK");
    }

    /// <summary>
    /// Handler for the support contact button.
    /// Allows user to contact support via a specified method (e.g., email).
    /// </summary>
    private async void OnContactSupportClicked(object sender, EventArgs e)
    {
        // Placeholder for contacting support
        await DisplayAlert("Contact Support", "Please contact support at support@nsri.org.za", "OK");
    }

    /// <summary>
    /// Handler for the logout button.
    /// Logs the user out and navigates back to the login page.
    /// </summary>
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirmLogout = await DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");

        if (confirmLogout)
        {
            // Perform logout actions (clear session, etc.)
            // Navigate back to the login page
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

