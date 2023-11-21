using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorAPIClient.Dtos;

namespace BlazorAPIClient.DataServices
{
    public class GraphQlJsonPlaceholderDataService : IJsonPlaceholderDataService
    {
        private readonly HttpClient _httpClient;

        public GraphQlJsonPlaceholderDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto[]> GetAllUsers()
        {
            var queryObject = new
            {
                query = @"{ users { id name email phone } }",
                variables = new { }
            };

            var userQuery = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/graphql", userQuery);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var gqlData = await JsonSerializer.DeserializeAsync<GqlData>(
                await response.Content.ReadAsStreamAsync()
            );

            return gqlData.Data.Users;
        }
    }
}