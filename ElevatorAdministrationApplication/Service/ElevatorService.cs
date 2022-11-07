using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Pages.Elevator;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Service
{
    public class ElevatorService : IElevatorService
    {
        public ElevatorViewModel GetElevator(int id)
        {
            using var httpClient = new HttpClient();

            var data = httpClient.GetStringAsync($"https://agilewebapi.azurewebsites.net/api/Elevator/{id}").Result;

            return JsonConvert.DeserializeObject<ElevatorViewModel>(data);
        }

        public List<ElevatorListViewModel> GetElevators()
        {
            using var httpClient = new HttpClient();

            var data = httpClient.GetStringAsync("https://agilewebapi.azurewebsites.net/api/Elevator").Result;

            return JsonConvert.DeserializeObject<List<ElevatorListViewModel>>(data);
        }
    }
}