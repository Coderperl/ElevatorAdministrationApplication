using ElevatorAdministrationApplication.Data;
using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data;

namespace ElevatorAdministrationApplication.Pages.Cases
{
    [Authorize(Roles = "SecondLine Technician, Field Technician")]
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
            
            Cases = _caseService.GetCases().Select(c => new CaseViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Status = c.Status,
                CreatedBy = c.CreatedBy,
                Technician = c.Technician,
                CaseCreated = c.CaseCreated,
                CaseEnded = c.CaseEnded

            }).ToList();
        }
    }
}
