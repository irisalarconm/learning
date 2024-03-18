using pruebaTecnica.Models;

namespace pruebaTecnica.Services;

public class ClientService : IClientService
{
    ProductClientContext context;

    public ClientService(ProductClientContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Client> Get()
    {
        return context.Clients;
    }

    public async Task Save(Client cliente)
    {
        context.Add(cliente);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Client cliente)
    {
        var ActualClient = context.Clients.Find(id);

        if(ActualClient != null){
            ActualClient.NameClient = cliente.NameClient;
            ActualClient.LastnameClient = cliente.LastnameClient;
            ActualClient.DNIClient = cliente.DNIClient;
            ActualClient.AdressClient = cliente.AdressClient;
            ActualClient.Phone = cliente.Phone;
            ActualClient.status = cliente.status;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var ActualClient = context.Clients.Find();
        
        if(ActualClient != null){
            
            context.Remove(ActualClient);

            await context.SaveChangesAsync();
        }
    }



}

public interface IClientService
{
    IEnumerable<Client> Get();
    
    Task Save(Client cliente);

    Task Update(Guid id, Client cliente);

    Task Delete(Guid id);
}