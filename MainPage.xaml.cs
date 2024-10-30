using Microsoft.Maui.Controls;

namespace MauiAppNSRI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this; // Set the BindingContext to allow command bindings
    }

    // Commands for navigation buttons
    public Command NavigateToLogSession => new Command(async () => await GoToPage("LogSessionPage"));
    public Command NavigateToSessions => new Command(async () => await GoToPage("SessionsPage"));
    public Command NavigateToReports => new Command(async () => await GoToPage("ReportsPage"));
    public Command NavigateToProfile => new Command(async () => await GoToPage("ProfilePage"));
    public Command NavigateToSettings => new Command(async () => await GoToPage("SettingsPage"));
    public Command NavigateToHome => new Command(async () => await GoToPage("MainPage"));

    /// <summary>
    /// Helper method to navigate to a page by route.
    /// </summary>
    /// <param name="pageName">Name of the page to navigate to.</param>
    private async Task GoToPage(string pageName)
    {
        try
        {
            await Shell.Current.GoToAsync($"//{pageName}");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Navigation Error", $"Could not navigate to {pageName}: {ex.Message}", "OK");
        }
    }
}
