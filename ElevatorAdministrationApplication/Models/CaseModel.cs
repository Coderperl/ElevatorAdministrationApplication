using System.Text.Json.Serialization;

namespace ElevatorAdministrationApplication.Models
{
    public class CaseModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("elevator")]
        public ElevatorModel Elevator { get; set; }
        [JsonPropertyName("technician")]
        public TechnicianModel Technician { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
}
}
