using Maratona.Models;
using Maratona.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maratona.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaTarefaPage : ContentPage
    {
        private ListaTarefasViewModel ViewModel => BindingContext as ListaTarefasViewModel;

        public ListaTarefaPage(List<Tarefa> tarefas)
        {
            InitializeComponent();
            var ViewModelBinding = new ListaTarefasViewModel(this.Navigation, tarefas);
            BindingContext = ViewModelBinding;

            lvwTarefas.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var detalheTarefa = e.SelectedItem as Tarefa;
                    await this.Navigation.PushModalAsync(new DetalheTarefaPage(detalheTarefa));
                    ((ListView)sender).SelectedItem = null;
                }
            };
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            ViewModel.AddTarefaCommand.Execute(null);
        }

        private void OnEditarClicked(object sender, EventArgs e)
        {
            ViewModel.EditarTarefaCommand.Execute(sender);
            btnAdd.IsVisible = false;
            btnEdit.IsVisible = true;
        }

        private void OnEditButtonClicked(object sender, EventArgs e)
        {
            ViewModel.EditarButtonTarefaCommand.Execute(null);
            btnAdd.IsVisible = true;
            btnEdit.IsVisible = false;
        }

        private void OnDeletarClicked(object sender, EventArgs e)
        {
            ViewModel.DeleteTarefaCommand.Execute(sender);
        }
    }
}
