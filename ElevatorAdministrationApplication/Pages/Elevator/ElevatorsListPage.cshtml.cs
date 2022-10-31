using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElevatorAdministrationApplication.Pages.Elevator
{
    public class ElevatorsPageModel : PageModel
    {
        public List<ElevatorViewModel> Elevators { get; set; }
        public class ElevatorViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool ShutDown { get; set; }
        }
        public void OnGet()
        {

        }
    }
}
