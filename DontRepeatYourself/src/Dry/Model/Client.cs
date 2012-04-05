using System.Collections.Generic;

namespace Dry.Model
{
    public class Client
    {
        public Client()
        {
            Contacts = new List<ClientContact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IList<ClientContact> Contacts { get; set; }
    }
}
