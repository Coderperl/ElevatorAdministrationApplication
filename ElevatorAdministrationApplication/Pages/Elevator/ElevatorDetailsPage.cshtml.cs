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
		//byt till din egna iothub connectionstring
		private readonly string IotHub = "HostName=Fredriks-IoTHub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=oTaXRPi71jD6g3fi11SX0GUcrlnMq9IeJWpPaV/utSQ=";
     
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
                //byt till din egna iothub connectionstring i IotHub längst upp
                using ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(IotHub);

                var directMethod = new CloudToDeviceMethod("ShutDown");
                directMethod.SetPayloadJson(JsonConvert.SerializeObject(new { id = id }));
                await serviceClient.InvokeDeviceMethodAsync("elevatorDevice", directMethod);
                
                Id = id;
                GetElevator(Id);
                return RedirectToPage("ElevatorDetailsPage", new { id = Id });
            }
            catch 
            {
                Id = id;
                GetElevator(Id);
                return RedirectToPage("ElevatorDetailsPage", new { id = Id });
            }
        }

		public async Task<IActionResult> OnPostInvokeDirectMethodDoorAction(int id)
		{
			try
			{
				using ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(IotHub);

				var directMethod = new CloudToDeviceMethod("DoorAction");
				directMethod.SetPayloadJson(JsonConvert.SerializeObject(new { id = id }));
				await serviceClient.InvokeDeviceMethodAsync("elevatorDevice", directMethod);

				Id = id;
				GetElevator(Id);
				return RedirectToPage("ElevatorDetailsPage", new { id = Id });
			}
			catch
			{
				Id = id;
				GetElevator(Id);
				return RedirectToPage("ElevatorDetailsPage", new { id = Id });
			}
		}

	}
}
