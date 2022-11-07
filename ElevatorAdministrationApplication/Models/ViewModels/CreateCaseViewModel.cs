using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Models.ViewModels
{
    public class CreateCaseViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("elevatorId")]
        public int ElevatorId { get; set; }
        [JsonProperty("technicianId")]
        public int TechnicianId { get; set; }
        [JsonProperty("comments")]
        public List<CommentModel> Comments { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("createdBy")]
        public int CreatedBy { get; set; }
        [JsonProperty("caseCreated")]
        public DateTime CaseCreated { get; set; }
        [JsonProperty("caseEnded")]
        public DateTime CaseEnded { get; set; }
    }
}
