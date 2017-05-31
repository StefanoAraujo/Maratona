using Maratona.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maratona.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheTarefaPage : ContentPage
    {
        public DetalheTarefaPage(Tarefa detalheTarefa)
        {
            InitializeComponent();
            BindingContext = detalheTarefa;
        }
    }
}
