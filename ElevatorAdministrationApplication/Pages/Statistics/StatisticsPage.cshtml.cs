using ElevatorAdministrationApplication.Models;
using Google.DataTable.Net.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;
using System;
using System.Text.Json;

namespace ElevatorAdministrationApplication.Pages.Statistics
{
    public class StatisticsPageModel : PageModel
    {
        
        public void OnGetAsync()
        {
            
        }
        //private async Task<ElevatorModel[]> AllElevatorsAsync()
        //{
        //    HttpClient client = new HttpClient();
        //    var stream = client.GetStreamAsync("https://agilewebapi.azurewebsites.net/api/Elevator");
        //    var data = await JsonSerializer.DeserializeAsync<ElevatorModel[]>(await stream);

        //    return data;
        //}
        //private async Task<CaseModel[]> AllCasesAsync()
        //{
        //    HttpClient client = new HttpClient();
        //    var stream = client.GetStreamAsync("https://agilewebapi.azurewebsites.net/api/Case");
        //    var data = await JsonSerializer.DeserializeAsync<CaseModel[]>(await stream);

        //    return data;
        //}

        //public async Task<IActionResult> OnGetElevatorsStatus()
        //{
        //    var elevators = await AllElevatorsAsync();
        //    int active = 0;
        //    int inactive = 0;

        //    var data = elevators.Select(a => new
        //    {
        //        Name = a.ElevatorStatus.Equals("Active") ? ++active : ++inactive

        //    }).ToList();
        //    var dt = new Google.DataTable.Net.Wrapper.DataTable();
        //    dt.AddColumn(new Column(ColumnType.String, "Status", "Status"));
        //    dt.AddColumn(new Column(ColumnType.Number, "Active", "Active"));
        //    dt.AddColumn(new Column(ColumnType.Number, "InActive", "InActive"));

        //    var row1 = dt.NewRow();
        //    row1.AddCell(new Cell("Status"));
        //    row1.AddCell(new Cell(active));
        //    row1.AddCell(new Cell(inactive));
        //    dt.AddRow(row1);
            
        //    return Content(dt.GetJson());
        //}
        //public async Task<IActionResult> OnGetCasesStatus()
        //{
        //    var cases = await AllCasesAsync();
        //    int started = 0;
        //    int notstarted = 0;

        //    var data = cases.Select(a => new
        //    {
        //        Status = a.Status.Equals("Started") ? ++started :++notstarted

        //    }).ToList();
        //    var dt = new Google.DataTable.Net.Wrapper.DataTable();
        //    dt.AddColumn(new Column(ColumnType.String, "Name", "Name"));
        //    dt.AddColumn(new Column(ColumnType.Number, "Status", "Status"));

        //    var row1 = dt.NewRow();
        //    row1.AddCell(new Cell("Started"));
        //    row1.AddCell(new Cell(started));
        //    dt.AddRow(row1);

        //    var row2 = dt.NewRow();
        //    row2.AddCell(new Cell("Not Started"));
        //    row2.AddCell(new Cell(notstarted));
        //    dt.AddRow(row2);

        //    return Content(dt.GetJson());
        //}
    }
}
