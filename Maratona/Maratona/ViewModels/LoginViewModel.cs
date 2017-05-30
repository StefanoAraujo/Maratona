using Maratona.Helpers;
using Maratona.Models;
using Maratona.Services;
using Maratona.Views;
using System.Linq;
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

            FacebookUser facebookUser = await azureService.GetUserAsync();
            var user = UsuarioService.FacebookParaUsuario(facebookUser);
            await _navigation.PushAsync(new MainPage(user));
            RemoveLoginPage();
        }

        async void ExecuteEntrarCommand()
        {
            Usuario usuario = UsuarioService.NovoUsuario();
            await _navigation.PushAsync(new MainPage(usuario));
            RemoveLoginPage();
        }

        void RemoveLoginPage()
        {
            var stackNavigation = _navigation.NavigationStack.ToList();
            foreach(var page in stackNavigation)
            {
                if (page.GetType() == typeof(LoginPage))
                    _navigation.RemovePage(page);
            }
        }
    }
}
