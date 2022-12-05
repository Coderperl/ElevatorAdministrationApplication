using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ElevatorAdministrationApplication.Pages.Cases
{
    [Authorize(Roles = "SecondLine Technician, Field Technician")]
    [BindProperties]
    public class CaseUpdatePageModel : PageModel
    {
        private readonly ICaseService _caseService;
        private readonly ITechnicianService _technicianService;
        private readonly IElevatorService _elevatorService;

        public CaseUpdatePageModel(ICaseService caseService, ITechnicianService technicianService, IElevatorService elevatorService)
        {
            _caseService = caseService;
            _technicianService = technicianService;
            _elevatorService = elevatorService;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ElevatorModel Elevator { get; set; }
        public TechnicianModel Technician { get; set; }
        public List<CommentModel> Comments { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CaseCreated { get; set; }
        public DateTime CaseEnded { get; set; }
        public string Comment { get; set; }

        public List<SelectListItem> AllStatus { get; set; }
        public List<SelectListItem> AllTechnicians { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casemodel = _caseService.GetCase(id);
            if (casemodel == null)
            {
                return NotFound();
            }
            Id = casemodel.Id;
            Name = casemodel.Name;
            Elevator = casemodel.Elevator;
            Technician = casemodel.Technician;
            Comments = casemodel.Comments;
            Status = casemodel.Status;
            CreatedBy = casemodel.CreatedBy;
            CaseCreated = casemodel.CaseCreated;
            CaseEnded = casemodel.CaseEnded;
            SetLists();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {           
            var currentCase = new UpdateCaseViewModel() 
            {
                TechnicianId = Technician.Id,
                Status = Status,
                Comment = Comment,
                CaseEnded = DateTime.Now,
            };

            try
            {
                _caseService.UpdateCases(currentCase, Id);

            }
            catch (Exception ex) { }

            return RedirectToPage("./CasesListPage");
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
            var t = _technicianService.GetTechnicians().Where(tech => tech.Role == "Field Technician");
            list.Add(new SelectListItem
            { 
                Text = "Select Technician",
                Value = 0.ToString(),                 
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
    }
}
