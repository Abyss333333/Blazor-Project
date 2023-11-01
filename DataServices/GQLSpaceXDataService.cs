using System.Text;
using System.Text.Json;
using BlazorAPIClient.DTO;

namespace BlazorAPIClient.DataServices
{
    public class GQLSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpClient;

        public GQLSpaceXDataService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public async Task<LaunchDto[]> GetAllLaunches()
        {
            var queryObject = new
            {
                query = @"{launches{id is_tentative mission_name launch_date_local}}",
                variables = new { }
            };
            var launchQuery = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("graphql", launchQuery);

            if (response.IsSuccessStatusCode)
            {
                var gqlData = await JsonSerializer.DeserializeAsync<GqlData>(await response.Content.ReadAsStreamAsync());
                return gqlData.Data.Launches;
            }
            return null;
        }
    }
}