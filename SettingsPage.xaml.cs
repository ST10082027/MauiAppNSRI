using Microsoft.Maui.Storage;

namespace MauiAppNSRI;

/// <summary>
/// Settings page for user preferences and app configurations.
/// </summary>
public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        LoadSettings();
    }

    /// <summary>
    /// Navigates back to the MainPage or pops from navigation stack if available.
    /// </summary>
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }

    /// <summary>
    /// Loads user preferences for theme, font size, notifications, and other settings.
    /// </summary>
    private void LoadSettings()
    {
        SessionRemindersSwitch.IsToggled = Preferences.Get("SessionRemindersEnabled", true);
        FeatureAlertsSwitch.IsToggled = Preferences.Get("FeatureAlertsEnabled", true);
        SafetyTipsSwitch.IsToggled = Preferences.Get("SafetyTipsEnabled", false);
        ThemePicker.SelectedIndex = Preferences.Get("SelectedTheme", 0); // Default: Light theme
        FontSizePicker.SelectedIndex = Preferences.Get("SelectedFontSize", 1); // Default: Medium font
        OfflineModeSwitch.IsToggled = Preferences.Get("OfflineModeEnabled", false);
    }

    /// <summary>
    /// Toggles notification preferences and saves changes.
    /// </summary>
    private void OnNotificationToggled(object sender, ToggledEventArgs e)
    {
        if (sender == SessionRemindersSwitch)
            Preferences.Set("SessionRemindersEnabled", e.Value);
        else if (sender == FeatureAlertsSwitch)
            Preferences.Set("FeatureAlertsEnabled", e.Value);
        else if (sender == SafetyTipsSwitch)
            Preferences.Set("SafetyTipsEnabled", e.Value);
    }

    /// <summary>
    /// Changes and saves the app theme based on user selection.
    /// </summary>
    private void OnThemeChanged(object sender, EventArgs e)
    {
        bool isDarkTheme = ThemePicker.SelectedItem?.ToString() == "Dark";
        Application.Current.UserAppTheme = isDarkTheme ? AppTheme.Dark : AppTheme.Light;
        Preferences.Set("SelectedTheme", isDarkTheme ? 1 : 0);
    }

    /// <summary>
    /// Changes and saves the font size preference based on user selection.
    /// </summary>
    private void OnFontSizeChanged(object sender, EventArgs e)
    {
        Preferences.Set("SelectedFontSize", FontSizePicker.SelectedIndex);
    }

    /// <summary>
    /// Clears the app cache and provides feedback to the user.
    /// </summary>
    private async void OnClearCacheClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Clear Cache", "Cache cleared successfully.", "OK");
        // TODO: Implement actual cache-clearing logic
    }

    /// <summary>
    /// Toggles offline mode and saves preference.
    /// </summary>
    private void OnOfflineModeToggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("OfflineModeEnabled", e.Value);
    }

    /// <summary>
    /// Placeholder for the change password feature.
    /// </summary>
    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Change Password", "Password change feature coming soon.", "OK");
    }

    #region Support and Legal Actions

    /// <summary>
    /// Event handler for opening the help center.
    /// </summary>
    private async void OnHelpCenterClicked(object sender, EventArgs e) =>
        await DisplayAlert("Help Center", "Help content coming soon.", "OK");

    /// <summary>
    /// Opens contact support information.
    /// </summary>
    private async void OnContactSupportClicked(object sender, EventArgs e) =>
        await DisplayAlert("Contact Support", "Contact support at support@nsri.org.za", "OK");

    /// <summary>
    /// Placeholder for feedback submission.
    /// </summary>
    private async void OnSendFeedbackClicked(object sender, EventArgs e) =>
        await DisplayAlert("Send Feedback", "Feedback submission coming soon.", "OK");

    /// <summary>
    /// Displays terms and conditions content.
    /// </summary>
    private async void OnTermsClicked(object sender, EventArgs e) =>
        await DisplayAlert("Terms and Conditions", "Terms content coming soon.", "OK");

    /// <summary>
    /// Displays privacy policy content.
    /// </summary>
    private async void OnPrivacyPolicyClicked(object sender, EventArgs e) =>
        await DisplayAlert("Privacy Policy", "Privacy policy content coming soon.", "OK");
    #endregion
}
