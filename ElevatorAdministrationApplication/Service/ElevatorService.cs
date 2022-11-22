using ElevatorAdministrationApplication.API;
using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Pages.Elevator;
using Newtonsoft.Json;
using System.Net;

namespace ElevatorAdministrationApplication.Service
{
    public class ElevatorService : IElevatorService
    {
        private readonly string ApiUri = "https://localhost:7169/api/elevator/";
        public ElevatorModel GetElevator(int id)
        {
            using var httpClient = new HttpClient();

            var data = httpClient.GetStringAsync($"{ApiUri}{id}").Result;

            return JsonConvert.DeserializeObject<ElevatorModel>(data);
        }

        public List<ElevatorModel> GetElevators()
        {
            List<ElevatorModel> elevators = new List<ElevatorModel>();  

            WebApi api = new WebApi();

            var apiCall = api.apiReturnAsync(ApiUri);

            var apiData = apiCall.Result;

            if(apiData.Status == HttpStatusCode.OK)
            {
                elevators = JsonConvert.DeserializeObject<List<ElevatorModel>>(apiData.Data);
                return elevators;
            }
            return elevators;
        }
    }
}