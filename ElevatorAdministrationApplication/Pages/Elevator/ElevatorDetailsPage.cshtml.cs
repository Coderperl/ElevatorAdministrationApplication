using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Pages.Elevator
{
    public class ElevatorDetailsPageModel : PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime LastInspection { get; set; }
        public DateTime NextInspection { get; set; }
        public string MaximumWeight { get; set; }
        public bool Reboot { get; set; }
        public bool ShutDown { get; set; }
        public bool Door { get; set; }
        public int Floor { get; set; }
        public string ElevatorStatus { get; set; }
        public void OnGet(int id)
        {
            using var httpClient = new HttpClient();

            var data = httpClient.GetStringAsync($"https://agilewebapi.azurewebsites.net/api/Elevator/{id}").Result;
            
            var result = JsonConvert.DeserializeObject<ElevatorDetailsPageModel>(data);

            Id = id;
            Name = result.Name;
            Address = result.Address;
            LastInspection = result.LastInspection;
            NextInspection = result.NextInspection;
            MaximumWeight = result.MaximumWeight;
            Reboot = result.Reboot;
            ShutDown = result.ShutDown;
            Door = result.Door;
            Floor = result.Floor;
            ElevatorStatus = result.ElevatorStatus;
        }
    }
}
