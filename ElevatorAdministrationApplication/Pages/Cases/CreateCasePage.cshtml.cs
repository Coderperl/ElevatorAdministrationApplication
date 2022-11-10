using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElevatorAdministrationApplication.Pages.Cases
{
    [BindProperties]
    public class CreateCasePageModel : PageModel
    {
        private readonly ICaseService _caseService;
        private readonly ITechnicianService _technicianService;
        private readonly IElevatorService _elevatorService;

        public CreateCasePageModel(ICaseService caseService, ITechnicianService technicianService, IElevatorService elevatorService)
        {
            _caseService = caseService;
            _technicianService = technicianService;
            _elevatorService = elevatorService;
        }
        public string Name { get; set; }
        public int ElevatorId{ get; set; }
        public int TechnicianId { get; set; }
        public CommentModel Comment { get; set; } 
        public string Status { get; set; }
        public DateTime CaseCreated { get; set; }
        public DateTime CaseEnded { get; set; }
        public List<SelectListItem> AllStatus { get; set; }
        public List<SelectListItem> AllTechnicians { get; set; }
        public List<SelectListItem> AllElevators { get; set; }
        public void OnGet()
        {
            SetLists();
        }

        public IActionResult OnPost()
        {
            
            if (ModelState.IsValid)
            {
                var createCase = new CreateCaseViewModel();
                {
                    createCase.Name = Name;
                    createCase.ElevatorId = ElevatorId;
                    createCase.TechnicianId = TechnicianId;
                    createCase.Comment =
                        new CommentModel()
                        {
                            Issue = $"Case Created by {_technicianService.GetTechnician(TechnicianId).Name}" + Comment.Issue 
                        };
                    
                    createCase.Status = Status;
                    createCase.CreatedBy = TechnicianId;
                    createCase.CaseCreated = CaseCreated;
                    createCase.CaseEnded = CaseEnded;
                    _caseService.CreateCase(createCase);
                    return RedirectToPage("/Cases/CasesListPage");
                }
            }
            SetLists();
            return Page();
        }
        public void SetLists()
        {
            SetAllStatus();
            AllTechnicians = SetAllTechnicians();
            AllElevators = SetAllElevators();
        }
        public void SetAllStatus()
        {
            AllStatus = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "Not Started",
                    Value = "Not Started"
                },
                new SelectListItem()
                {
                    Text = "Started",
                    Value = "Started"
                },
                
                new SelectListItem()
                {
                    Text = "Resolved",
                    Value = "Resolved"
                },
            };
        }

        public List<SelectListItem> SetAllTechnicians()
        {
            var list = new List<SelectListItem>();
            var t = _technicianService.GetTechnicians();
            list.Add(new SelectListItem
            {
                Text = "Select Technician",
                Value = 0.ToString()
            });
            foreach (var tech in t)
            {
                list.Add(new SelectListItem
                {
                    Text = tech.Name,
                    Value = tech.Id.ToString()
                });
            }
            return list;
        }
        public List<SelectListItem> SetAllElevators()
        {
            var list = new List<SelectListItem>();
            var e = _elevatorService.GetElevators();
            list.Add(new SelectListItem
            {
                Text = "Select Elevator",
                Value = 0.ToString()
            });
            foreach (var tech in e)
            {
                list.Add(new SelectListItem
                {
                    Text = tech.Name,
                    Value = tech.Id.ToString()
                });
            }
            return list;
        }
    }
}
