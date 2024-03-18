using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();
    }
}
