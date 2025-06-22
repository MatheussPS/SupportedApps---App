using CRUDAppsSuportados.Models;
using CRUDAppsSuportados.Services;

namespace CRUDAppsSuportados
{
    public partial class MainPage : ContentPage
    {
        AppSuportadoService service = new AppSuportadoService();

        public MainPage()
        {
            InitializeComponent();
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

            await DisplayAlert("Results", ""+results, "OK");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}
