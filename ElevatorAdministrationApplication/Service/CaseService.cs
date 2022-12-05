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
        private readonly string ApiUri = "http://localhost:7169/api/case/";
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
