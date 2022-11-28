using ElevatorAdministrationApplication.API;
using ElevatorAdministrationApplication.Models;
using Newtonsoft.Json;
using System.Net;

namespace ElevatorAdministrationApplication.Service
{
    public class TechnicianService : ITechnicianService
    {
        private readonly string ApiUri = "http://localhost:7169/api/technician/";
        public TechnicianModel GetTechnician(int id)
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetStringAsync($"{ApiUri}{id}").Result;
            return JsonConvert.DeserializeObject<TechnicianModel>(data);

            TechnicianModel technician = new TechnicianModel();

            WebApi api = new WebApi();

            var apiCall = api.apiReturnAsync(ApiUri + id);

            var apiData = apiCall.Result;

            if (apiData.Status == HttpStatusCode.OK)
            {
                technician = JsonConvert.DeserializeObject<TechnicianModel>(apiData.Data);
                return technician;
            }
            return technician;
        }

        public List<TechnicianModel> GetTechnicians()
        {
            List<TechnicianModel> technicians = new List<TechnicianModel>();

            WebApi api = new WebApi();

            var apiCall = api.apiReturnAsync(ApiUri);

            var apiData = apiCall.Result;

            if (apiData.Status == HttpStatusCode.OK)
            {
                technicians = JsonConvert.DeserializeObject<List<TechnicianModel>>(apiData.Data);
                return technicians;
            }
            return technicians;

        }
    }
}
