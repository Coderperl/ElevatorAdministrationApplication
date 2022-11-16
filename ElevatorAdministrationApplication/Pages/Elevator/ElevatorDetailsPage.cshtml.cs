using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Pages.Elevator
{
    [BindProperties]
    public class ElevatorDetailsPageModel : PageModel
    {
        private readonly IElevatorService _elevatorService;
        public ElevatorDetailsPageModel(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }
        public int Id { get; set; }
        public ElevatorViewModel elevator;
        public void OnGet(int id)
        {
            Id = id;
            GetElevator(Id);
        }

        private void GetElevator(int id)
        {
            elevator = new ElevatorViewModel();

            var result = _elevatorService.GetElevator(id);

            elevator.Id = result.Id;
            elevator.Name = result.Name;
            elevator.Address = result.Address;
            elevator.LastInspection = result.LastInspection;
            elevator.NextInspection = result.NextInspection;
            elevator.MaximumWeight = result.MaximumWeight;
            elevator.Reboot = result.Reboot;
            elevator.ShutDown = result.ShutDown;
            elevator.Door = result.Door;
            elevator.Floor = result.Floor;
            elevator.ElevatorStatus = result.ElevatorStatus;
        }

        public async Task<IActionResult> OnPostInvokeMethodShutDown(int id)
        {
            try
            {
                 
                using ServiceClient serviceClient = ServiceClient.CreateFromConnectionString("HostName=kyh-iothub-2.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=oj0gqypXDJVBFRzURDHu3zM7Xcu0H2AXRwl7o9/JMiw=");

                var directMethod = new CloudToDeviceMethod("ShutDown");
                directMethod.SetPayloadJson(JsonConvert.SerializeObject(new { id = id }));
                await serviceClient.InvokeDeviceMethodAsync("elevatorDevice", directMethod);
                
                Id = id;
                GetElevator(Id);
                return Page();
            }
            catch 
            {
                Id = id;
                GetElevator(Id); 
                return Page(); 
            }
            

        }
        
    }
}
