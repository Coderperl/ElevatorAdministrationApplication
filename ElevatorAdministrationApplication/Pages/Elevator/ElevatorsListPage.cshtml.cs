using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data;

namespace ElevatorAdministrationApplication.Pages.Elevator
{
    [Authorize(Roles = "SecondLine Technician, Field Technician")]
    public class ElevatorsPageModel : PageModel
    {
        private readonly IElevatorService _elevatorService;
        public ElevatorsPageModel(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }
        public List<ElevatorListViewModel> Elevators { get; set; }

        public void OnGetAsync()
        {
            Elevators = _elevatorService.GetElevators().Select(c => new ElevatorListViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                ElevatorStatus = c.ElevatorStatus
            }).ToList();
        }
    }
}
