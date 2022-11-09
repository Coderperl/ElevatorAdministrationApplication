using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ElevatorAdministrationApplication.Models.ViewModels
{
    public class UpdateCaseViewModel
    {
        [JsonProperty("technicianId")]
        public int TechnicianId { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("caseEnded")]
        public DateTime CaseEnded { get; set; }
    }
}
