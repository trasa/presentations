using System.Collections.Generic;
using System.Linq;
using Dry.Model;

namespace Dry.Services
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly List<Client> clients = new List<Client>();

        public ClientRepository()
        {
            clients.Add(new Client
                           {
                               Id = 1,
                               Name = "Sue Client",
                               Contacts = new List<ClientContact>
                                              {
                                                  new ClientContact {FirstName = "Xavier", MiddleName = "J.", LastName = "Foobar"}
                                              }
                           });
        }

        public Client Get(int id)
        {
            return clients.SingleOrDefault(a => a.Id == id);
        }

        public void Save(Client client)
        {
            if (!clients.Contains(client))
                clients.Add(client);
        }
    }
}
