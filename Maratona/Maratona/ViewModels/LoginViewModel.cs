using Maratona.Helpers;
using Maratona.Models;
using Maratona.Services;
using Maratona.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Maratona.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private AzureService azureService;
        public Command LoginFacebookCommand { get; set; }
        public Command EntrarCommand { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            EntrarCommand = new Command(ExecuteEntrarCommand);
            LoginFacebookCommand = new Command(ExecuteLoginFacebookCommand);
            azureService = new AzureService();
        }

        async void ExecuteLoginFacebookCommand()
        {
            if (!Settings.IsLoggedIn)
                await azureService.LoginAsync();

            AuthClient facebookUser = await azureService.GetUserAsync();
            var user = UsuarioService.ClaimsParaUsuario(facebookUser);

            await _navigation.PushAsync(new MainPage(user));
        }

        async void ExecuteEntrarCommand()
        {
            Usuario usuario = UsuarioService.NovoUsuario();
            await _navigation.PushAsync(new MainPage(usuario));
        }
    }
}
