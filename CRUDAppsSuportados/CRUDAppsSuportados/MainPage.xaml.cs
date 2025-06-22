using CRUDAppsSuportados.Models;
using CRUDAppsSuportados.Services;
using CRUDAppsSuportados.ViewModels;
using Microsoft.Maui;

namespace CRUDAppsSuportados
{
    public partial class MainPage : ContentPage
    {
        AppSuportadoService service = new AppSuportadoService();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AppSuportadoViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            AppSuportadoModel model = new AppSuportadoModel();
            model.Nome = NomeEntry.Text;
            model.Descricao = DescEntry.Text;
            model.Referencia = RefEntry.Text;
            model.Situacao = SitEntry.Text;
            model.Id = 0;
            string results = await service.PostApp(model);

            BindingContext = new AppSuportadoViewModel();
            await DisplayAlert("Results", "" + results, "OK");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}