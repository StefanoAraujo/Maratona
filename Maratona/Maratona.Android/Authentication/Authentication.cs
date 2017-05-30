using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Maratona.Authentication;
using Xamarin.Forms;
using Maratona.Helpers;
using System;
using System.Diagnostics;

[assembly: Dependency(typeof(Maratona.Droid.Authentication.SocialAuthentication))]
namespace Maratona.Droid.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, 
                                                          MobileServiceAuthenticationProvider provider, 
                                                          IDictionary<string, string> paramameters)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception e)
            {
                //to do
                Debug.WriteLine("Erro na autenticação do usuário Android");
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}