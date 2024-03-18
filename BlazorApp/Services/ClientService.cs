using BlazorApp.Models;


namespace BlazorApp.Services
{
    public class ClientService : IClientService
    {

        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Client>> GetClients()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Client>>("/client");

            return response;
        }
    }
}
