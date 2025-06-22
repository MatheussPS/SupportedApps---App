using CRUDAppsSuportados.Models;
using CRUDAppsSuportados.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAppsSuportados.ViewModels
{
    class AppSuportadoViewModel
    {

        private readonly AppSuportadoService _appSuportadoService;
        public ObservableCollection<AppSuportadoModel> Apps { get; set; } = new ObservableCollection<AppSuportadoModel>();


        public AppSuportadoViewModel()
        {
            _appSuportadoService = new AppSuportadoService();
            showApps();
        }

        public async void showApps()
        {
            List<AppSuportadoModel> apps = await _appSuportadoService.GetAll();
            Apps.Clear();
            foreach (var app in apps)
            {
                Apps.Add(app);
            }
        }


    }
}
