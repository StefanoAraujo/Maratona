using Maratona.Models;
using Maratona.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System;

namespace Maratona.ViewModels
{
    public class ListaTarefasViewModel : BaseViewModel
    {
        private static int IndexOfNovaTarefa;
        private INavigation _navigation;

        private ObservableCollection<Tarefa> _listaTarefas;
        public ObservableCollection<Tarefa> ListaTarefas
        {
            get =>_listaTarefas;
            set => SetProperty(ref _listaTarefas, value);
        }

        private Tarefa _novaTarefa;
        public Tarefa NovaTarefa
        {
            get => _novaTarefa;
            set => SetProperty(ref _novaTarefa, value);
        }

        public Command RefreshCommand { get; set; }
        public Command EditarTarefaCommand { get; set; }
        public Command DeleteTarefaCommand { get; set; }
        public Command AddTarefaCommand { get; set; }
        public Command EditarButtonTarefaCommand { get; set; }

        public ListaTarefasViewModel(INavigation navigation, List<Tarefa> tarefas)
        {
            _listaTarefas = new ObservableCollection<Tarefa>();
            _novaTarefa = new Tarefa();
            _navigation = navigation;

            RefreshCommand = new Command(ExecuteRefreshCommand);
            EditarButtonTarefaCommand = new Command(ExecuteEditarButtonTarefaCommand);
            EditarTarefaCommand = new Command(ExecuteEditarTarefaCommand);
            DeleteTarefaCommand = new Command(ExecuteDeleteTarefaCommand);
            AddTarefaCommand = new Command(ExecuteAddTarefaCommand);

            if (tarefas != null)
            {
                ObservableCollection<Tarefa> temp = new ObservableCollection<Tarefa>();
                foreach (var tarefa in tarefas)
                    temp.Add(tarefa);

                ListaTarefas = temp;
            }
        }

        private void ExecuteAddTarefaCommand()
        {
            NovaTarefa.Id = ListaTarefas.Count + 1;
            ListaTarefas.Add(NovaTarefa);
        }

        private void ExecuteDeleteTarefaCommand(object obj)
        {
            var menu = obj as MenuItem;
            var tarefa = menu.BindingContext as Tarefa;
            ListaTarefas.Remove(tarefa);
        }

        private void ExecuteEditarTarefaCommand(object obj)
        {
            var menu = obj as MenuItem;
            var tarefa = menu.BindingContext as Tarefa;
            IndexOfNovaTarefa = tarefa.Id;
            NovaTarefa = tarefa;
        }

        void ExecuteEditarButtonTarefaCommand()
        {
            var tarefa = ListaTarefas.FirstOrDefault(c => c.Id == IndexOfNovaTarefa);
            var i = ListaTarefas.IndexOf(tarefa);
            ListaTarefas[i] = NovaTarefa;
            _novaTarefa = NovaTarefa = null;
            _novaTarefa = new Tarefa();
        }

        void ExecuteRefreshCommand()
        {
            ObservableCollection<Tarefa> lista = _listaTarefas;
            _listaTarefas = null;
            ListaTarefas = lista;
        }
    }
}
