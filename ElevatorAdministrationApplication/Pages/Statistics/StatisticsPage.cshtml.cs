using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;
using ElevatorAdministrationApplication.Service;
using Google.DataTable.Net.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;
using System;
using System.Data;
using System.Text.Json;

namespace ElevatorAdministrationApplication.Pages.Statistics
{
    [Authorize(Roles = "SecondLine Technician, Field Technician")]
    public class StatisticsPageModel : PageModel
    {
        private readonly ICaseService _caseService;
        private readonly ITechnicianService _technicianService;
        private readonly IElevatorService _elevatorService;

        public StatisticsPageModel(ICaseService caseService, ITechnicianService technicianService, IElevatorService elevatorService)
        {
            _caseService = caseService;
            _technicianService = technicianService;
            _elevatorService = elevatorService;
        }

        public void OnGetAsync()
        {
            
        }
        private async Task<ElevatorListViewModel[]> AllElevatorsAsync()
        {
            HttpClient client = new HttpClient();
            var stream = client.GetStreamAsync("http://localhost:7169/api/Elevator");
            var data = await JsonSerializer.DeserializeAsync<ElevatorListViewModel[]>(await stream);

            return data;
        }
        private async Task<CreateCaseViewModel[]> AllCasesAsync()
        {
            HttpClient client = new HttpClient();
            var stream = client.GetStreamAsync("http://localhost:7169/api/Case");
            var data = await JsonSerializer.DeserializeAsync<CreateCaseViewModel[]>(await stream);

            return data;
        }

        public async Task<IActionResult> OnGetElevatorsStatus()
        {
            var elevators = await AllElevatorsAsync();
            int active = 0;
            int inactive = 0;

            var data = elevators.Select(a => new
            {
                Name = a.ElevatorStatus.Equals("Active") ? ++active : ++inactive

            }).ToList();
            var dt = new Google.DataTable.Net.Wrapper.DataTable();
            dt.AddColumn(new Column(ColumnType.String, "Status", "Status"));
            dt.AddColumn(new Column(ColumnType.Number, "Active", "Active"));
            dt.AddColumn(new Column(ColumnType.Number, "Not Active", "Not Active"));

            var row1 = dt.NewRow();
            row1.AddCell(new Cell("Status"));
            row1.AddCell(new Cell(active));
            row1.AddCell(new Cell(inactive));
            dt.AddRow(row1);
            
            return Content(dt.GetJson());
        }
        public async Task<IActionResult> OnGetCasesStatus()
        {
            var cases = await AllCasesAsync();
            int started = 0;
            int notstarted = 0;
            int resolved = 0;
            foreach (var item in cases)
            {
                if (item.Status == "Started")
                {
                    ++started;
                }
                else if (item.Status == "Resolved")
                {
                    ++resolved;
                }
                else
                {
                    ++notstarted;
                }
            }
            
            var dt = new Google.DataTable.Net.Wrapper.DataTable();
            dt.AddColumn(new Column(ColumnType.String, "Name", "Name"));
            dt.AddColumn(new Column(ColumnType.Number, "Status", "Status"));

            var row1 = dt.NewRow();
            row1.AddCell(new Cell("Started"));
            row1.AddCell(new Cell(started));
            dt.AddRow(row1);

            var row2 = dt.NewRow();
            row2.AddCell(new Cell("Not Started"));
            row2.AddCell(new Cell(notstarted));
            dt.AddRow(row2);

            var row3 = dt.NewRow();
            row3.AddCell(new Cell("Resolved"));
            row3.AddCell(new Cell(resolved));
            
            dt.AddRow(row3);

            return Content(dt.GetJson());
        }
    }
}
