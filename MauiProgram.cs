using Microsoft.Extensions.Logging;

namespace MauiAppNSRI
{
    /// <summary>
    /// MauiProgram configures the Maui application, including services,
    /// logging, and font registration.
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// Creates and configures the main MAUI application instance.
        /// </summary>
        /// <returns>A configured instance of <see cref="MauiApp"/>.</returns>
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Set the main application class and configure fonts
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    // Register fonts for application-wide use with aliases
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // Enable debug logging in development mode for easier troubleshooting
            builder.Logging.AddDebug();
#endif

            // Build and return the configured MauiApp instance
            return builder.Build();
        }
    }
}

