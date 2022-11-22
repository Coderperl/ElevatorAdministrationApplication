using Newtonsoft.Json;
using System.Text;

namespace ElevatorAdministrationApplication.API
{
    public class WebApi : IWebApi
    {
        public async Task<ReturnData> apiReturnAsync(string api)
        {
            ReturnData returnData = new ReturnData();

            using var httpClient = new HttpClient();

            var data = new HttpResponseMessage();

            try
            {
                data = await httpClient.GetAsync($"{api}");
            }
            catch
            {
                return returnData;
            }
            
            if(data.IsSuccessStatusCode)
            {
                returnData.Data = await data.Content.ReadAsStringAsync();
                returnData.Status = data.StatusCode;
            }

            return returnData;
        }

        
        public async Task<ReturnData> apiPostAsync<T>(string api, T obj)
        {
            ReturnData returnData = new ReturnData();
            var payload = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            using var httpClient = new HttpClient();

            var data = new HttpResponseMessage();

            try
            {
                data = await httpClient.PostAsync($"{api}", httpContent);
            }
            catch
            {
                return returnData;
            }

            if (data.IsSuccessStatusCode)
            {
                returnData.Data = await data.Content.ReadAsStringAsync();
                returnData.Status = data.StatusCode;
            }

            return returnData;
        }

        public async Task<ReturnData> apiUpdateAsync<T>(string api, T obj)
        {
            ReturnData returnData = new ReturnData();
            var payload = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            using var httpClient = new HttpClient();

            var data = new HttpResponseMessage();

            try
            {
                data = await httpClient.PutAsync($"{api}", httpContent);
            }
            catch
            {
                return returnData;
            }

            if (data.IsSuccessStatusCode)
            {
                returnData.Data = await data.Content.ReadAsStringAsync();
                returnData.Status = data.StatusCode;
            }

            return returnData;
        }
    }


}