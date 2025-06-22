using CRUDAppsSuportados.Models;
using CRUDAppsSuportados.Services;
using CRUDAppsSuportados.ViewModels;
using Microsoft.Maui;
using System.Threading.Tasks;

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
            await DisplayAlert("Resultado", "" + results, "OK");
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var app = (AppSuportadoModel)button.CommandParameter;

            await DisplayAlert("Model", app.Nome, "OK");
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var app = (AppSuportadoModel)button.CommandParameter;

            bool results = await service.deleteUser(app.Id);
            BindingContext = new AppSuportadoViewModel();
            if (results) await DisplayAlert("Results", "Sucesso!", "OK");

        }
    }
}