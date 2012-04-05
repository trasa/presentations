using System;
using Dry.Model;
using Dry.Services;

namespace Dry
{
    public partial class ClientContacts : InjectablePage
    {
        [Injectable]
        protected ClientRepository ClientRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        public int ClientId
        {
            get
            {
                int i;
                int.TryParse(Request.QueryString["ClientId"], out i);
                return i;
            }
        }

        /// <summary>
        /// Should we show this form "read only" or not?
        /// </summary>
        public bool ReadOnly { get { return string.Equals(Request.QueryString["ReadOnly"], "true", StringComparison.InvariantCultureIgnoreCase); } }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            var contact = new ClientContact
            {
                FirstName = firstName.Text,
                MiddleName = middleName.Text,
                LastName = lastName.Text,
                Title = title.Text,
                Notes = notes.Text,
            };
            /*
            if (address1.HasData)
            {
                contact.Addresses.Add(address1.CreateAddress());
            }
            if (address2.HasData)
            {
                contact.Addresses.Add(address2.CreateAddress());
            }
            if (address3.HasData)
            {
                contact.Addresses.Add(address3.CreateAddress());
            }
            */

            var client = ClientRepository.Get(ClientId);
            client.Contacts.Add(contact);
            ClientRepository.Save(client);
        }
    }
}
