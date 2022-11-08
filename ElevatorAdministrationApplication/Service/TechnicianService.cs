using ElevatorAdministrationApplication.Models;
using Newtonsoft.Json;

namespace ElevatorAdministrationApplication.Service
{
    public class TechnicianService : ITechnicianService
    {
        public TechnicianModel GetTechnician(int id)
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"https://agilewebapi.azurewebsites.net/api/technician/{id}").Result;
            return JsonConvert.DeserializeObject<TechnicianModel>(data);
        }

        public List<TechnicianModel> GetTechnicians()
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"https://agilewebapi.azurewebsites.net/api/technician").Result;
            return JsonConvert.DeserializeObject<List<TechnicianModel>>(data);

        }
    }
}
