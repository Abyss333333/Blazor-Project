using System.Net.Http.Json;
using BlazorAPIClient.DTO;

namespace BlazorAPIClient.DataServices
{
    public class RESTSpaceXDataService : ISpaceXDataService
    {

        private readonly HttpClient _httpclient;
        public RESTSpaceXDataService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<LaunchDto[]> GetAllLaunches()
        {
            return await _httpclient.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}