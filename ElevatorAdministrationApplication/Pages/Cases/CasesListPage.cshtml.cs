using ElevatorAdministrationApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElevatorAdministrationApplication.Pages.Cases
{
    public class CasesListPageModel : PageModel
    {
        public List<CaseViewModel> Cases { get; set; }
        public class CaseViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ElevatorModel Elevator { get; set; }
            public TechnicianModel Technician { get; set; }
            public List<CommentModel> Comments { get; set; }
            public enum CaseStatus
            {
                Started,
                NotStarted,
                Finished
            }
        }
        public void OnGet()
        {
        }
    }
}
