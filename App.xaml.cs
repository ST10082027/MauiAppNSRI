using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace MauiAppNSRI
{
    public partial class App : Application
    {
        private const string TenantId = "3e57956f-0918-4dd2-b42f-58f5e80c798d";
        private const string ClientId = "de982f15-c311-4eab-9023-9de3f512e40d";
        private const string RedirectUri = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        private static IPublicClientApplication _pca;

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            InitializeEntraID();
        }

        private void InitializeEntraID()
        {
            _pca = PublicClientApplicationBuilder.Create(ClientId)
                .WithRedirectUri(RedirectUri)
                .WithTenantId(TenantId)
                .Build();
        }

        public static async Task<AuthenticationResult> SignInAsync(string[] scopes)
        {
            try
            {
                var accounts = await _pca.GetAccountsAsync();
                return await _pca.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                                 .ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                return await _pca.AcquireTokenInteractive(scopes).ExecuteAsync();
            }
        }
    }
}