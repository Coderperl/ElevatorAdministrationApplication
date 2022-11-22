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
            CaseModel Case = new CaseModel();

            WebApi api = new WebApi();

            var apiCall = api.apiReturnAsync(ApiUri + id);

            var apiData = apiCall.Result;

            if (apiData.Status == HttpStatusCode.OK)
            {
                Case = JsonConvert.DeserializeObject<CaseModel>(apiData.Data);
            }

            return Case;
        }

        public List<CaseModel> GetCases()
        {
            List<CaseModel> Cases = new List<CaseModel>();

            WebApi api = new WebApi();

            var apiCall = api.apiReturnAsync(ApiUri);

            var apiData = apiCall.Result;

            if (apiData.Status == HttpStatusCode.OK)
            {
                Cases = JsonConvert.DeserializeObject<List<CaseModel>>(apiData.Data);
            }

            return Cases;
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
