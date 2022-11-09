using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ElevatorAdministrationApplication.Models.ViewModels
{
    public class ElevatorListViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("elevatorStatus")]
        public string ElevatorStatus { get; set; }
    }
}
