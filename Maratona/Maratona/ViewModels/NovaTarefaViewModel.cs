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
            AddTarefaCommand = new Command(ExecuteAddTarefaCommand, CanExecuteAddTarefaCommand);
        }

        async void ExecuteAddTarefaCommand()
        {
            await _navigation.PopAsync();
        }

        bool CanExecuteAddTarefaCommand()
        {
            if (string.IsNullOrWhiteSpace(Tarefa.Nome) || string.IsNullOrWhiteSpace(Tarefa.Descricao)
                    || string.IsNullOrWhiteSpace(Tarefa.Local) || Tarefa.Data == null)
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
