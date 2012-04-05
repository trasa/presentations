using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Collections.Generic;
using System.Xml;

public partial class Autofill2 : System.Web.UI.Page
{
    private static BitArray _zips;
    private static Dictionary<string, string[]> _locations;
    private static object _lock = new object();
    private static bool _initialized = false;

    [WebMethod]
    public static string[] GetCityAndStateFromZipCode(string zip)
    {
        if (String.IsNullOrEmpty(zip) || zip.Length != 5)
            return null;

        lock (_lock)
        {
            if (!_initialized)
                InitializeData();
        }

        string[] location = null;
        _locations.TryGetValue(zip, out location);
        return location;
    }

    private static void InitializeData()
    {
        _zips = new BitArray(100000, false);
        _locations = new Dictionary<string, string[]>(1000);

        XmlTextReader reader = null;

        try
        {
            reader = new XmlTextReader(HttpContext.Current.Server.MapPath("~/App_Data/ZipCodes.xml"));
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "City")
                {
                    reader.Read();
                    string city = reader.Value;     // Read city name
                    reader.Read();
                    reader.Read();
                    reader.Read();
                    string state = reader.Value;    // Read state name
                    reader.Read();
                    reader.Read();
                    reader.Read();
                    string zip = reader.Value;      // Read zip code

                    _zips[Convert.ToInt32(zip)] = true;
                    _locations.Add(zip, new string[2] { city, state });
                }
            }

            _initialized = true;
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }
}