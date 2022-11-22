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
    }


}