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
        private Usuario _user;
        public Usuario User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private INavigation _navigation;
        public Command MinhasTarefasCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public MainViewModel(INavigation navigation, Usuario usuario)
        {
            if (usuario != null)
                User = usuario;

            _navigation = navigation;
            MinhasTarefasCommand = new Command(ExecuteMinhasTarefasCommand);
            LogoutCommand = new Command(ExecuteLogoutCommand);
        }

        private async void ExecuteMinhasTarefasCommand()
        {
            await _navigation.PushAsync(new ListaTarefaPage(User.Tarefas));
        }

        void ExecuteLogoutCommand()
        {
            AzureService.LogoutAsync(this._navigation);
        }
    }
}
