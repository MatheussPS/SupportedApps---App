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
        bool buttonToUpdate = false;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AppSuportadoViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string results;

            AppSuportadoModel model = new AppSuportadoModel();
            model.Nome = NomeEntry.Text;
            model.Descricao = DescEntry.Text;
            model.Referencia = RefEntry.Text;
            model.Situacao = SitEntry.Text;
            model.Id = Preferences.Get("idEditado", 0);

            if (buttonToUpdate)
            {
                results = await service.PutApp(model);
                BindingContext = new AppSuportadoViewModel();
                await DisplayAlert("Resultado", "" + results, "OK");
                buttonForm.Text = "Adicionar App";
                resetarCampos();
                buttonToUpdate = false;
                return;
            }
            results = await service.PostApp(model);

            BindingContext = new AppSuportadoViewModel();
            await DisplayAlert("Resultado", "" + results, "OK");
            resetarCampos();
        }

        public void atualizarCamposParaModificarApp(AppSuportadoModel model)
        {
            NomeEntry.Text = model.Nome;
            DescEntry.Text = model.Descricao;
            RefEntry.Text = model.Referencia;
            SitEntry.Text = model.Situacao;
        }

        public void resetarCampos()
        {
            NomeEntry.Text = "";
            DescEntry.Text = "";
            RefEntry.Text = "";
            SitEntry.Text = "";
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            AppSuportadoModel app = (AppSuportadoModel)button.CommandParameter;

            buttonToUpdate = true;

            buttonForm.Text = "Atualize aqui!";
            atualizarCamposParaModificarApp(app);

            Preferences.Set("idEditado", app.Id);
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