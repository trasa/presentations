using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace PirateShipProvider
{
    /// <summary>
    /// Summary description for PirateShipFactory
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PirateShipFactory : System.Web.Services.WebService
    {

        [WebMethod]
        public PirateShip BuildShip(string shipName)
        {
            return new PirateShip {Name = shipName};
        }
    }
}
