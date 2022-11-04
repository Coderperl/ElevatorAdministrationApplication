using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Pages.Elevator
{
    public class ElevatorsPageModel : PageModel
    {
        public List<ElevatorViewModel> Elevators { get; set; }
        public class ElevatorViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ElevatorStatus { get; set; }
        }
        public void OnGetAsync()
        {
            using var httpClient = new HttpClient();

            var data = httpClient.GetStringAsync("https://agilewebapi.azurewebsites.net/api/Elevator").Result;

            var elevators = JsonConvert.DeserializeObject<List<ElevatorViewModel>>(data);

            Elevators = elevators;
        }
    }
}
