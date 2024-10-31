using Microsoft.Maui.Storage;    // For secure storage
using Microsoft.Identity.Client; // For Entra ID (Azure AD) authentication
using System.Threading.Tasks;
using System.Linq;

namespace MauiAppNSRI
{
    public partial class App : Application
    {
        // Azure AD Configuration
        private const string ClientId = "de982f15-c311-4eab-9023-9de3f512e40d";
        private const string TenantId = "common";
        private const string RedirectUri = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        private static IPublicClientApplication _pca;

        public App()
        {
            InitializeComponent();                // Initialize XAML components
            MainPage = new AppShell();            // Set the main application shell
            InitializeEntraID();                  // Configure Entra ID for authentication
            _ = TrySilentLoginAsync();            // Attempt silent login to retrieve a cached token if available
        }

        /// <summary>
        /// Initializes the Entra ID (Azure AD) client application with configuration.
        /// </summary>
        private void InitializeEntraID()
        {
            _pca = PublicClientApplicationBuilder.Create(ClientId)
                .WithRedirectUri(RedirectUri)
                .WithTenantId(TenantId)
                .Build();
        }

        /// <summary>
        /// Handles user sign-in and retrieves authentication token with specified scopes.
        /// </summary>
        /// <param name="scopes">Permissions scopes required for sign-in.</param>
        /// <returns>AuthenticationResult with access token if successful.</returns>
        public static async Task<AuthenticationResult> SignInAsync(string[] scopes)
        {
            var accounts = await _pca.GetAccountsAsync();
            try
            {
                var authResult = await _pca.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
                await SecureStorage.SetAsync("authToken", authResult.AccessToken);
                return authResult;
            }
            catch (MsalUiRequiredException)
            {
                return await InteractiveSignInAsync(scopes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Silent login failed: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Attempts interactive login if silent login fails.
        /// </summary>
        private static async Task<AuthenticationResult> InteractiveSignInAsync(string[] scopes)
        {
            try
            {
                var authResult = await _pca.AcquireTokenInteractive(scopes).ExecuteAsync();
                await SecureStorage.SetAsync("authToken", authResult.AccessToken);
                return authResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Interactive login failed: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Attempts silent login using cached token, navigates to MainPage if successful.
        /// </summary>
        private async Task TrySilentLoginAsync()
        {
            var token = await SecureStorage.GetAsync("authToken");
            if (string.IsNullOrEmpty(token)) return;

            var accounts = await _pca.GetAccountsAsync();
            try
            {
                var authResult = await _pca.AcquireTokenSilent(new[] { "User.Read" }, accounts.FirstOrDefault()).ExecuteAsync();
                if (authResult != null)
                {
                    Console.WriteLine("Silent login successful.");
                    MainPage = new MainPage();
                }
            }
            catch (MsalUiRequiredException)
            {
                Console.WriteLine("Token expired or requires re-authentication.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Silent login error: {ex.Message}");
            }
        }
    }
}
