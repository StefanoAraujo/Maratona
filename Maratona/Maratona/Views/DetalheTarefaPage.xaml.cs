using Maratona.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maratona.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheTarefaPage : ContentPage
    {
        public DetalheTarefaPage(ref Tarefa detalheTarefa)
        {
            InitializeComponent();
            BindingContext = detalheTarefa;
        }
    }
}
