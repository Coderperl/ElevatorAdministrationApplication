using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Pages.Elevator;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Service
{
    public class ElevatorService : IElevatorService
    {
        public ElevatorModel GetElevator(int id)
        {
            using var httpClient = new HttpClient();

            var data = httpClient.GetStringAsync($"https://agilewebapi.azurewebsites.net/api/Elevator/{id}").Result;

            return JsonConvert.DeserializeObject<ElevatorModel>(data);
        }

        public List<ElevatorModel> GetElevators()
        {
            using var httpClient = new HttpClient();

            var data = httpClient.GetStringAsync("https://agilewebapi.azurewebsites.net/api/Elevator").Result;

            return JsonConvert.DeserializeObject<List<ElevatorModel>>(data);
        }
    }
}