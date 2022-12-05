using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        [JsonProperty("issue")]
        public string Issue { get; set; }
    }
}
