using Microsoft.Maui.Controls;  // Ensures access to Shell and Routing functionality

namespace MauiAppNSRI
{
    /// <summary>
    /// AppShell class defines the application's main navigation structure.
    /// Inherits from Shell to use Shell-based navigation for simplified, declarative routing.
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Constructor for AppShell that initializes the components 
        /// and registers routes for each primary page in the application.
        /// </summary>
        public AppShell()
        {
            InitializeComponent(); // Initializes XAML components defined in AppShell.xaml

            // Registering routes for each page to enable programmatic navigation
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));              // Route to Login Page
            Routing.RegisterRoute("RegistrationPage", typeof(RegistrationPage)); // Route to Registration Page
            Routing.RegisterRoute("MainPage", typeof(MainPage));                 // Route to Main Page
            Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));           // Route to Profile Page
            Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));         // Route to Settings Page
            Routing.RegisterRoute("SessionsPage", typeof(SessionsPage));         // Route to Sessions Page
        }
    }
}

