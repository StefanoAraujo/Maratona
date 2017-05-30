using Maratona.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Maratona.ViewModels
{
    public class ListaTarefasViewModel : BaseViewModel
    {
        private ObservableCollection<Tarefa> _listaTarefas;
        public ObservableCollection<Tarefa> ListaTarefas
        {
            get =>_listaTarefas;
            set => SetProperty(ref _listaTarefas, value);
        }

        public ListaTarefasViewModel(List<Tarefa> tarefas)
        {
            if (tarefas != null)
            {
                ObservableCollection<Tarefa> temp = new ObservableCollection<Tarefa>();
                foreach (var tarefa in tarefas)
                    temp.Add(tarefa);

                ListaTarefas = temp;
            }
        }
    }
}
