using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElevatorAdministrationApplication.Pages.Cases
{
    public class CreateCasePageModel : PageModel
    {
        private readonly ICaseService _caseService;
        private readonly ITechnicianService _technicianService;

        public CreateCasePageModel(ICaseService caseService, ITechnicianService technicianService)
        {
            _caseService = caseService;
            _technicianService = technicianService;
        }
        public string Name { get; set; }
        public int ElevatorId{ get; set; }
        public int TechnicianId { get; set; }
        public CommentModel Comment { get; set; } = new CommentModel();
        public string Status { get; set; }
        public int CreatedBy { get; set; }
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
                var createCase = new CaseModel();
                {
                    createCase.Name = Name;
                    createCase.Elevator.Id = ElevatorId;
                    createCase.Technician.Id = TechnicianId;
                    createCase.Comments = new List<CommentModel>()
                    {
                        Comment
                    };
                    createCase.CaseCreated = CaseCreated;
                    createCase.CaseEnded = CaseEnded;
                    createCase.CreatedBy = CreatedBy;
                    createCase.Status = Status;
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
        }
        public void SetAllStatus()
        {
            AllStatus = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "InActive",
                    Value = "InActive"
                },
                new SelectListItem()
                {
                    Text = "Active",
                    Value = "Active"
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
        //public void SetAllElevators()
        //{
        //    var elevators = new List<ElevatorModel>();
        //    foreach (var elevator in elevators)
        //    {
        //        var elev = _caseService.GetCases().Select(x => x.Elevator == elevator);
        //        AllElevators = new List<SelectListItem>
        //        {
        //            new SelectListItem()
        //            {
        //                Text = elev.ToString(),
        //                Value = Elevator.Name
        //            },
        //        };
        //    }
        //}
    }
}
