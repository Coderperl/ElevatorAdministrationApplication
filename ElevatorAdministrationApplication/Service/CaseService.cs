using System.Text;
using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Service
{
    public class CaseService :ICaseService
    {
        private readonly string ApiUri = "https://localhost:7169/api/case/";
        public CaseModel GetCase(int id)
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"{ApiUri}{id}").Result;
            return JsonConvert.DeserializeObject<CaseModel>(data);
        }

        public List<CaseModel> GetCases()
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"{ApiUri}").Result;
            return JsonConvert.DeserializeObject<List<CaseModel>>(data);

        }

        public Status UpdateCases(UpdateCaseViewModel updateCase, int id)
        {
            var payload = JsonConvert.SerializeObject(updateCase);
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var data = httpClient.PutAsync($"{ApiUri}{id}", httpContent).Result;
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
            var data = httpClient.PostAsync($"{ApiUri}", httpContent).Result;
            if (data.IsSuccessStatusCode)
            {
                return Status.Ok;
            }
            return Status.Error;
        }
    }
}
