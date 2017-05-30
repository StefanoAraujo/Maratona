using Maratona.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;
using Maratona.Views;

namespace Maratona.ViewModels
{
    public class ListaTarefasViewModel : BaseViewModel
    {
        private ObservableCollection<Tarefa> _listaTarefas;
        private INavigation _navigation;

        public ObservableCollection<Tarefa> ListaTarefas
        {
            get =>_listaTarefas;
            set => SetProperty(ref _listaTarefas, value);
        }

        public Command DeleteTarefaCommand { get; set; }
        public Command AddTarefaCommand { get; set; }

        public ListaTarefasViewModel(INavigation navigation, List<Tarefa> tarefas)
        {
            _navigation = navigation;
            AddTarefaCommand = new Command(ExecuteAddTarefaCommand);
            DeleteTarefaCommand = new Command(ExecuteDeleteTarefaCommand);

            if (tarefas != null)
            {
                ObservableCollection<Tarefa> temp = new ObservableCollection<Tarefa>();
                foreach (var tarefa in tarefas)
                    temp.Add(tarefa);

                ListaTarefas = temp;
            }
        }

        private async void ExecuteAddTarefaCommand(object obj)
        {
            NovaTarefaPage novaTarefa = new NovaTarefaPage();
            await _navigation.PushModalAsync(novaTarefa);

            //var tarefa = novaTarefa.
        }

        private void ExecuteDeleteTarefaCommand(object obj)
        {
            
        }
    }
}
