using System.Net;
using System.Text;
using ElevatorAdministrationApplication.API;
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
            WebApi api = new WebApi();

            var apiCall = api.apiUpdateAsync(ApiUri + id, updateCase);
            var apiData = apiCall.Result;
            if (apiData.Status == HttpStatusCode.OK)
            {
                return Status.Ok;
            }
            return Status.Error;
        }

        public Status CreateCase(CreateCaseViewModel createCase)
        {
            WebApi api = new WebApi();

            var apiCall = api.apiPostAsync(ApiUri, createCase);
            var apiData = apiCall.Result;
            if (apiData.Status == HttpStatusCode.OK)
            {
                return Status.Ok;
            }
            return Status.Error;
        }
    }
}
