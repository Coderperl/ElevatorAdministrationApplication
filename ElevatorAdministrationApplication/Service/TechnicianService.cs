using ElevatorAdministrationApplication.Models;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Service
{
    public class TechnicianService : ITechnicianService
    {
        private readonly string ApiUri = "https://localhost:7169/api/technician/";
        public TechnicianModel GetTechnician(int id)
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"{ApiUri}{id}").Result;
            return JsonConvert.DeserializeObject<TechnicianModel>(data);
        }

        public List<TechnicianModel> GetTechnicians()
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"{ApiUri}").Result;
            return JsonConvert.DeserializeObject<List<TechnicianModel>>(data);

        }
    }
}
