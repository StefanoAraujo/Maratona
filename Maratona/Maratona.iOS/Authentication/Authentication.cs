using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Maratona.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Maratona.Helpers;

[assembly: Dependency(typeof(Maratona.iOS.Authentication.SocialAuthentication))]
namespace Maratona.iOS.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client,
                                       MobileServiceAuthenticationProvider provider,
                                       IDictionary<string, string> paramameters)
        {
            try
            {
                var current = GetController();
                var user = await client.LoginAsync(current, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception e)
            {
                // to do
                throw;
            }
        }

        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            if (root == null) return null;

            var current = root;
            while (current.PresentedViewController != null)
            {
                current = current.PresentedViewController;
            }

            return current;
        }
    }
}