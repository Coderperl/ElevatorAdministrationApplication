using System.Net;

namespace ElevatorAdministrationApplication.API
{
    public interface IWebApi
    {
        public Task<ReturnData> apiReturnAsync(string api);
        public Task<ReturnData> apiPostAsync<T>(string api, T obj);
        public Task<ReturnData> apiUpdateAsync<T>(string api, T obj);
    }

    public class ReturnData
    {
        public string? Data { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
