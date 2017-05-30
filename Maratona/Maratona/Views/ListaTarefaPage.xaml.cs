using Maratona.Models;
using Maratona.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maratona.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaTarefaPage : ContentPage
    {
        public ListaTarefaPage(List<Tarefa> tarefas)
        {
            InitializeComponent();
            BindingContext = new ListaTarefasViewModel(this.Navigation, tarefas);

            lvwTarefas.ItemTapped += async (sender, e) =>
            {
                var detalheTarefa = e.Item as Tarefa;
                await this.Navigation.PushAsync(new DetalheTarefaPage(detalheTarefa));
            };
        }
    }
}
