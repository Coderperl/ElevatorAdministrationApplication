using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Pages.Elevator;
using Newtonsoft.Json;

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
            using var httpClient = new HttpClient();

            var data = httpClient.GetStringAsync($"{ApiUri}").Result;

            return JsonConvert.DeserializeObject<List<ElevatorModel>>(data);
        }
    }
}