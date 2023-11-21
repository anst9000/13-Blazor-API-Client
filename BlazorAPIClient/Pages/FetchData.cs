using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorAPIClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAPIClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient Http { get; set; }
        private UserDto[] users;

        protected override async Task OnInitializedAsync()
        {
            users = await Http.GetFromJsonAsync<UserDto[]>("/users");
        }
    }
}