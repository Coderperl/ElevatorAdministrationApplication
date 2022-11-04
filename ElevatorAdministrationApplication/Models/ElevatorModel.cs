using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ElevatorAdministrationApplication.Models
{
    public class ElevatorModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("lastInspection")]
        public DateTime LastInspection { get; set; }
        [JsonPropertyName("nextInspection")]
        public DateTime NextInspection { get; set; }
        [JsonPropertyName("maximumWeight")]
        public string MaximumWeight { get; set; }
        [JsonPropertyName("reboot")]
        public bool Reboot { get; set; }
        [JsonPropertyName("shutDown")]
        public bool ShutDown { get; set; }
        [JsonPropertyName("door")]
        public bool Door { get; set; }
        [JsonPropertyName("floor")]
        public int Floor { get; set; }
        [JsonPropertyName("elevatorStatus")]
        public string ElevatorStatus { get; set; }
    }
}
