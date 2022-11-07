using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Models
{
    public class CommentModel
    {
        [JsonProperty("issue")]
        public string Issue { get; set; }
    }
}
