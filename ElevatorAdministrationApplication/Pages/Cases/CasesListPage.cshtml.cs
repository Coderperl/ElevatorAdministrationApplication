using ElevatorAdministrationApplication.Data;
using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Pages.Cases
{
    public class CasesListPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ICaseService _caseService;

        public CasesListPageModel(ICaseService caseService)
        {
            _caseService = caseService;
        }
        public List<CaseViewModel> Cases { get; set; }
        
        public void OnGet()
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"https://agilewebapi.azurewebsites.net/api/case").Result;
            Cases = JsonConvert.DeserializeObject<List<CaseViewModel>>(data);


            
        }
    }
}
