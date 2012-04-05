using System;
using Dry.Model;
using Dry.Services;

namespace Dry
{
    public partial class AgentContacts : InjectablePage
    {
        [Injectable]
        protected AgentRepository AgentRepository { get; set; }

        /// <summary>
        /// The agent who's contacts we're viewing.
        /// </summary>
        public int AgentId
        {
            get
            {
                int i;
                int.TryParse(Request.QueryString["AgentId"], out i);
                return i;
            }
        }

        /// <summary>
        /// Should we show this form "read only" or not?
        /// </summary>
        public bool ReadOnly { get { return string.Equals(Request.QueryString["ReadOnly"], "true", StringComparison.InvariantCultureIgnoreCase); } }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var contact = new AgentContact
                              {
                                  FirstName = firstName.Text,
                                  MiddleName = middleName.Text,
                                  LastName = lastName.Text,
                                  Title = title.Text,
                                  Notes = notes.Text,
                              };
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
            
            var agent = AgentRepository.Get(AgentId);
            agent.Contacts.Add(contact);
            AgentRepository.Save(agent);

        }
    }
}
