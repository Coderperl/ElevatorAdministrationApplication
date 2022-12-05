using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ElevatorAdministrationApplication.Models.ViewModels
{
    public class CreateCaseViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("elevatorId")]
        public int ElevatorId { get; set; }
        [JsonPropertyName("technicianId")]
        public int TechnicianId { get; set; }
        [JsonPropertyName("comment")]
        public CommentModel Comment { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("createdBy")]
        public int CreatedBy { get; set; }
        [JsonPropertyName("caseCreated")]
        public DateTime CaseCreated { get; set; }
        [JsonPropertyName("caseEnded")]
        public DateTime CaseEnded { get; set; }
    }
}
