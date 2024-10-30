using Microsoft.Maui.Storage;

namespace MauiAppNSRI;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        LoadSettings();
    }

    /// <summary>
    /// Back button navigation to MainPage.
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
    /// Loads initial settings, such as theme, font size, and notification preferences.
    /// </summary>
    private void LoadSettings()
    {
        // Load saved preferences with defaults if no value is set
        SessionRemindersSwitch.IsToggled = Preferences.Get("SessionRemindersEnabled", true);
        FeatureAlertsSwitch.IsToggled = Preferences.Get("FeatureAlertsEnabled", true);
        SafetyTipsSwitch.IsToggled = Preferences.Get("SafetyTipsEnabled", false);
        ThemePicker.SelectedIndex = Preferences.Get("SelectedTheme", 0); // 0 for Light, 1 for Dark
        FontSizePicker.SelectedIndex = Preferences.Get("SelectedFontSize", 1); // Default to Medium
        OfflineModeSwitch.IsToggled = Preferences.Get("OfflineModeEnabled", false);
    }

    /// <summary>
    /// Event handler for toggling notifications.
    /// </summary>
    private void OnNotificationToggled(object sender, ToggledEventArgs e)
    {
        // Save notification preferences
        if (sender == SessionRemindersSwitch)
            Preferences.Set("SessionRemindersEnabled", e.Value);
        else if (sender == FeatureAlertsSwitch)
            Preferences.Set("FeatureAlertsEnabled", e.Value);
        else if (sender == SafetyTipsSwitch)
            Preferences.Set("SafetyTipsEnabled", e.Value);
    }

    /// <summary>
    /// Event handler for theme selection.
    /// </summary>
    private void OnThemeChanged(object sender, EventArgs e)
    {
        string selectedTheme = (string)ThemePicker.SelectedItem;
        bool isDarkTheme = selectedTheme == "Dark";

        // Set app theme and save preference
        Application.Current.UserAppTheme = isDarkTheme ? AppTheme.Dark : AppTheme.Light;
        Preferences.Set("SelectedTheme", isDarkTheme ? 1 : 0); // Save as 0 for Light, 1 for Dark
    }

    /// <summary>
    /// Event handler for font size selection.
    /// </summary>
    private void OnFontSizeChanged(object sender, EventArgs e)
    {
        string selectedFontSize = (string)FontSizePicker.SelectedItem;

        // Save selected font size for use in other parts of the app if necessary
        Preferences.Set("SelectedFontSize", FontSizePicker.SelectedIndex); // Save as index for consistency
    }

    /// <summary>
    /// Event handler for clearing cache.
    /// </summary>
    private async void OnClearCacheClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Clear Cache", "Cache cleared successfully.", "OK");
        // Placeholder: Implement actual cache-clearing logic here
    }

    /// <summary>
    /// Event handler for toggling offline mode.
    /// </summary>
    private void OnOfflineModeToggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("OfflineModeEnabled", e.Value);
    }

    /// <summary>
    /// Event handler for changing user password
    /// </summary>
    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Change Password", "Password change feature coming soon.", "OK");
    }

    /// <summary>
    /// Event handlers for support, feedback, and legal buttons.
    /// </summary>
    private async void OnHelpCenterClicked(object sender, EventArgs e) => await DisplayAlert("Help Center", "Help content coming soon.", "OK");
    private async void OnContactSupportClicked(object sender, EventArgs e) => await DisplayAlert("Contact Support", "Contact support at support@nsri.org.za", "OK");
    private async void OnSendFeedbackClicked(object sender, EventArgs e) => await DisplayAlert("Send Feedback", "Feedback submission coming soon.", "OK");
    private async void OnTermsClicked(object sender, EventArgs e) => await DisplayAlert("Terms and Conditions", "Terms content coming soon.", "OK");
    private async void OnPrivacyPolicyClicked(object sender, EventArgs e) => await DisplayAlert("Privacy Policy", "Privacy policy content coming soon.", "OK");
}

