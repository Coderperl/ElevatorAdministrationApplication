using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElevatorAdministrationApplication.Pages.Cases
{
    [Authorize(Roles="SecondLine Technician, Field Technician")]
    public class CaseDetailsPageModel : PageModel
    {
        private readonly ICaseService _caseService;

		public int Id { get; set; }
		public string Name { get; set; }
		public ElevatorModel Elevator { get; set; }
		public TechnicianModel Technician { get; set; }
		public List<CommentModel> Comments { get; set; }
		public string Status { get; set; }
		public int CreatedBy { get; set; }
		public DateTime CaseCreated { get; set; }
		public DateTime CaseEnded { get; set; }

        public CaseDetailsPageModel(ICaseService caseService)
        {
            _caseService = caseService;
        }

        public IActionResult OnGet(int id)
        {
            var caseModel = _caseService.GetCase(id);

            Id = caseModel.Id;
            Name = caseModel.Name;
            Elevator = caseModel.Elevator;
            Technician = caseModel.Technician;
            Status = caseModel.Status;
            CaseCreated = caseModel.CaseCreated;
            CaseEnded = caseModel.CaseEnded;
            CreatedBy = caseModel.CreatedBy;
            Comments = caseModel.Comments;
      

            return Page();
        }
    }
}
