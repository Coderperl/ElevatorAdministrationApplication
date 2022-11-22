using System.Net;

namespace ElevatorAdministrationApplication.API
{
    public interface IWebApi
    {
        public Task<ReturnData> apiReturnAsync(string api);
    }

    public class ReturnData
    {
        public string Data { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
