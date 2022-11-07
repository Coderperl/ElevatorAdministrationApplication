using System.Text;
using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Service
{
    public class CaseService :ICaseService 
    {
        
        public CaseModel GetCase(int id)
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"https://agilewebapi.azurewebsites.net/api/case/{id}").Result;
            return JsonConvert.DeserializeObject<CaseModel>(data);
        }

        public List<CaseModel> GetCases()
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"https://agilewebapi.azurewebsites.net/api/case").Result;
            return JsonConvert.DeserializeObject<List<CaseModel>>(data);

        }

        public Status UpdateCases(CaseModel updateCase, int id)
        {
            var payload = JsonConvert.SerializeObject(updateCase);
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var data = httpClient.PutAsync($"https://agilewebapi.azurewebsites.net/api/case/{id}", httpContent).Result;
            if (data.IsSuccessStatusCode)
            {
                return Status.Ok;
            }

            return Status.Error;
        }

        public Status CreateCase(CreateCaseViewModel createCase)
        {
            var payload = JsonConvert.SerializeObject(createCase);
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var data = httpClient.PostAsJsonAsync($"https://agilewebapi.azurewebsites.net/api/case", httpContent).Result;
            if (data.IsSuccessStatusCode)
            {
                return Status.Ok;
            }
            return Status.Error;
        }
    }
}
