using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorAPIClient.Dtos;

namespace BlazorAPIClient.DataServices
{
    public class RestJsonPlaceholderDataService : IJsonPlaceholderDataService
    {
        private readonly HttpClient _httpClient;

        public RestJsonPlaceholderDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto[]> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<UserDto[]>("/users");
        }
    }
}