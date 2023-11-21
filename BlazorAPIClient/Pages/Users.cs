using System.Threading.Tasks;
using BlazorAPIClient.DataServices;
using BlazorAPIClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAPIClient.Pages
{
    public partial class Users
    {
        [Inject]
        IJsonPlaceholderDataService JsonPlaceholderDataService { get; set; }

        private UserDto[] users;

        protected override async Task OnInitializedAsync()
        {
            users = await JsonPlaceholderDataService.GetAllUsers();
        }
    }
}