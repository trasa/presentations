using System;
using System.Collections.Generic;
using Dry.Model;

namespace Dry
{
    public partial class AddressInfo : System.Web.UI.UserControl
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAddressType();
            }
        }

        public bool HasData
        {
            get
            {
                return address1.Text.Trim().Length > 0;
            }
        }

        private void BindAddressType()
        {
            addressType.DataSource = new List<KeyValuePair<int, string>>
                                         {
                                             new KeyValuePair<int, string>(1, "Home"),
                                             new KeyValuePair<int, string>(2, "Work"),
                                         };
            addressType.DataBind();
        }

        public AgentContactAddress CreateAddress()
        {
            return new AgentContactAddress
                       {
                           AddressType = int.Parse(addressType.SelectedValue),
                           Line1 = address1.Text,
                           Line2 = address2.Text,
                           City = city.Text,
                           State = state.Text,
                           PostalCode = postalCode.Text,
                       };
        }
    }
}