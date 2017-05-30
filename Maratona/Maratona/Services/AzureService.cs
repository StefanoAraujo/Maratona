using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Maratona.Authentication;
using Maratona.Helpers;
using System;
using System.Collections.Generic;
using Maratona.Models;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

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

        public async Task<FacebookUser> GetUserAsync()
        {
            try
            {
                List<AuthClient> user = await Client.InvokeApiAsync<List<AuthClient>>("/.auth/me");
                string acessToken = user[0].access_token;

                var facebookUrl = $"https://graph.facebook.com/v2.9/me?fields=id%2Cname%2Cbirthday%2Cemail%2Cfirst_name%2Cgender%2Clast_name%2Cpicture%7Burl%2Cheight%2Cwidth%2Cis_silhouette%7D&access_token={acessToken}";
                var httpClient = new HttpClient();
                var userJson = await httpClient.GetStringAsync(facebookUrl);
                var facebookProfile = JsonConvert.DeserializeObject<FacebookUser>(userJson);

                Settings.FacebookUser = facebookProfile;
                return facebookProfile;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Erro", e.Message, "ok");
                return null;
            }
        }
    }

}
