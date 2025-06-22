using CRUDAppsSuportados.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace CRUDAppsSuportados.Services
{
    public class AppSuportadoService
    {
        private HttpClient httpClient;
        private JsonSerializerOptions jsonSerializerOptions;

        public AppSuportadoService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<string> PostApp(AppSuportadoModel model)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return "Sem internet";
            }

            try
            {

                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{Globals.apiBaseURL}/AppSuportado", content);
                Debug.WriteLine("URL: " + $"{Globals.apiBaseURL}/AppSuportado");
                if (response.IsSuccessStatusCode) {
                    return "Sucesso!";
                }
                return response.StatusCode.ToString();
            }
            catch (Exception e)
            {
                
                return e.ToString();
            }

        }

        public async Task<bool> deleteUser(long id)
        {

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet) // valida se tem internet
            {
                return false;
            }

            try
            {

                var response = await httpClient.DeleteAsync($"{Globals.apiBaseURL}/AppSuportado/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERRO -----" + ex.Message);
            }

            return false;

        }

        public async Task<List<AppSuportadoModel>> GetAll()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet) // valida se tem internet
            {
                return null;
            }
            try
            {
                var response = await httpClient.GetAsync($"{Globals.apiBaseURL}/AppSuportado/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<AppSuportadoModel> apps = JsonSerializer.Deserialize<List<AppSuportadoModel>>(jsonResponse, jsonSerializerOptions);
                    return apps;
                }
                return null;
            }catch(Exception e)
            {
                return null;
            }
        }

        public async Task<string> PutApp(AppSuportadoModel model)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return "Sem internet!";
            }

            try
            {

                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync($"{Globals.apiBaseURL}/AppSuportado", content);

                if (response.IsSuccessStatusCode)
                {
                    return "Atualizado com Sucesso!";
                }
                return response.StatusCode.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();

            }

        }

    }
}
