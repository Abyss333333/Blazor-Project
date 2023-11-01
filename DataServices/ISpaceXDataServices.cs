using BlazorAPIClient.DTO;

namespace BlazorAPIClient.DataServices
{
    public interface ISpaceXDataService
    {
        Task<LaunchDto[]> GetAllLaunches();
    }
}