using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System.Data;

namespace ElevatorAdministrationApplication.Pages.Elevator
{
    [Authorize(Roles = "SecondLine Technician, Field Technician")]
    [BindProperties]
    public class ElevatorDetailsPageModel : PageModel
    {
        //byt till din egna iothub connectionstring
        private readonly string IotHub =
            "HostName=CoderPer-IotHub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=ma+LRFaad+UGhf/jh36X7aYMV2DlhsJ45OLbAnkzkrU=";

        private readonly IElevatorService _elevatorService;

        public List<SelectListItem> AllFloors { get; set; }
        public int CurrentFloor { get; set; }

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
            AllFloors = SetAllFloors();
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
            elevator.MaxFloor = result.MaxFloor;
            elevator.MinFloor = result.MinFloor;
            elevator.ElevatorType = result.ElevatorType;
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
        public async Task<IActionResult> OnPostInvokeMethodChangeChangeFloor(int id)
        {
            try
            {

                //byt till din egna iothub connectionstring i IotHub längst upp
                using ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(IotHub);
                var directMethod = new CloudToDeviceMethod("ChangeFloor");
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

        public async Task<IActionResult> OnPostInvokeMethodReset(int id)
        {
            try
            {
                //byt till din egna iothub connectionstring    
                using ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(IotHub);

                var directMethod = new CloudToDeviceMethod("Reset");
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

        public async Task<IActionResult> OnPostDirectMethodChangeFloor(int id, int currentfloor)
        {
            try
            {
                
                using ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(IotHub);

                var directMethod = new CloudToDeviceMethod("ChangeFloor");
                directMethod.SetPayloadJson(JsonConvert.SerializeObject(new { id = id, floor = currentfloor }));
                await serviceClient.InvokeDeviceMethodAsync("elevatorDevice", directMethod);

                Id = id;
                GetElevator(Id);
                return RedirectToPage("ElevatorDetailsPage", new { id = Id, floor = currentfloor });
            }
            catch
            {
                Id = id;
                GetElevator(Id);
                return RedirectToPage("ElevatorDetailsPage", new { id = Id, floor = currentfloor });
            }
        }
        public List<SelectListItem> SetAllFloors()
        {
            var list = new List<SelectListItem>();

            list.Add(new SelectListItem
            {
                Text = elevator.Floor.ToString(),
                Value = elevator.Floor.ToString()
            });

            for (int i = elevator.MinFloor; i <= elevator.MaxFloor; i++)
            {
                list.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            return list;
        }
    }
}

		

