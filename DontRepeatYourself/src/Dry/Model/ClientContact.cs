using System.Collections.Generic;

namespace Dry.Model
{
    public class ClientContact
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public string Title { get; set; }

        public IList<ClientContactAddress> Addresses { get; set; }
    }
}
