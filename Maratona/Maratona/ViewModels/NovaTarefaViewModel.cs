using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maratona.Models;
using Xamarin.Forms;

namespace Maratona.ViewModels
{
    public class NovaTarefaViewModel : BaseViewModel
    {
        private Tarefa _tarefa;
        private INavigation _navigation;

        public Tarefa Tarefa
        {
            get => _tarefa;
            set
            {
                if(SetProperty(ref _tarefa, value))
                    AddTarefaCommand.ChangeCanExecute();
            }
        }

        public Command AddTarefaCommand { get; set; }

        public NovaTarefaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            AddTarefaCommand = new Command(ExecuteAddTarefaCommand);
        }

        async void ExecuteAddTarefaCommand()
        {
            await _navigation.PopModalAsync();
        }

        bool CanExecuteAddTarefaCommand()
        {
            if ((string.IsNullOrWhiteSpace(_tarefa.Nome) || string.IsNullOrWhiteSpace(_tarefa.Descricao)) || (string.IsNullOrWhiteSpace(_tarefa.Local) || _tarefa.Data == null))
                return false;
            else
                return true;
        }

        public Tarefa getTarefa()
        {
            return this._tarefa;
        }
    }
}
