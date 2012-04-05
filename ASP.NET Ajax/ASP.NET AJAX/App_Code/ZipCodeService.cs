using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Xml;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;

[ScriptService]
public class ZipCodeService : System.Web.Services.WebService
{
    private static BitArray _zips;
    private static Dictionary<string, string[]> _locations;
    private static object _lock = new object();
    private static bool _initialized = false;

    [WebMethod]
    public string[] GetMatchingZipCodes(string prefixText, int count)
    {
        int len = prefixText.Length;
        if (len < 1 || len > 5)
            return null;

        lock (_lock)
        {
            if (!_initialized)
                InitializeData();
        }

        int mul = (int)(Math.Pow(10.0, (double)(5 - len)));
        int index = Convert.ToInt32(prefixText) * mul;
        int max = index + mul - 1;

        string[] zips = new string[count];
        int matches = 0;

        while (index < _zips.Count && index <= max && matches < count)
        {
            if (_zips[index])
            {
                zips[matches++] = index.ToString("d5");
            }
            index++;
        }

        if (matches < count)
            Array.Resize(ref zips, matches);

        return zips;
    }

    [WebMethod]
    public string[] GetCityAndStateFromZipCode(string zip)
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

    private void InitializeData()
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