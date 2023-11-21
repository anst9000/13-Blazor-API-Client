using System.Threading.Tasks;
using BlazorAPIClient.Dtos;

namespace BlazorAPIClient.DataServices
{
    public interface IJsonPlaceholderDataService
    {
        Task<UserDto[]> GetAllUsers();
    }
}