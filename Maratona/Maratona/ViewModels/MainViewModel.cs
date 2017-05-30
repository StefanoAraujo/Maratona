using Maratona.Helpers;
using Maratona.Models;
using Maratona.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using Maratona.Views;

namespace Maratona.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private INavigation _navigation;

        private Usuario _user;
        public Usuario User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public Command MinhasTarefasCommand { get; set; }

        public MainViewModel(INavigation navigation, Usuario usuario)
        {
            if (usuario != null)
                User = usuario;

            _navigation = navigation;
            MinhasTarefasCommand = new Command(ExecuteMinhasTarefasCommand);
        }

        private void ExecuteRecarregarDadosCommand()
        {
            User = UsuarioService.ClaimsParaUsuario(Settings.FacebookClient);
        }

        private async void ExecuteMinhasTarefasCommand()
        {
            await _navigation.PushAsync(new ListaTarefaPage(User.Tarefas));
        }
    }
}
