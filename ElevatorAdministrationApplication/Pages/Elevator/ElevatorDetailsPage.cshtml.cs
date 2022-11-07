using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Pages.Elevator
{
    public class ElevatorDetailsPageModel : PageModel
    {
        private readonly IElevatorService _elevatorService;
        public ElevatorDetailsPageModel(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }

        public ElevatorViewModel elevator;
        public void OnGet(int id)
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
    }
}
