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
            BindingContext = new ListaTarefasViewModel(this.Navigation, tarefas);

            lvwTarefas.ItemSelected += async (sender, e) =>
            {
                var detalheTarefa = e.SelectedItem as Tarefa;
                await this.Navigation.PushModalAsync(new DetalheTarefaPage(detalheTarefa));
            };
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            ViewModel.AddTarefaCommand.Execute(null);
            etyNome.Text = "";
            etyLocal.Text = "";
            etyDescricao.Text = "";
            dtData.Date = DateTime.Now;
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

            etyNome.Text = "";
            etyLocal.Text = "";
            etyDescricao.Text = "";
            dtData.Date = DateTime.Now;
        }

        private void OnDeletarClicked(object sender, EventArgs e)
        {
            ViewModel.DeleteTarefaCommand.Execute(sender);
        }
    }
}
