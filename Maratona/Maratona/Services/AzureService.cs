using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Maratona.Authentication;
using Maratona.Helpers;
using System;
using System.Collections.Generic;
using Maratona.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Maratona.Services.AzureService))]
namespace Maratona.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "http://healthtrackmobile.azurewebsites.net/";

        public MobileServiceClient Client { get; set; }
        public static bool UseAuth { get; set; }

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não foi possivel efetuar o login, tente novamente", "ok"));

                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;

                return true;
            }
        }

        public async Task<AuthClient> GetUserAsync()
        {
            try
            {
                List<AuthClient> user = await Client.InvokeApiAsync<List<AuthClient>>("/.auth/me");
                Settings.FacebookClient = user[0];

                return user[0];
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Erro", e.Message, "ok");
                return null;
            }
        }
    }

}
