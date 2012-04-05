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

[ScriptService]
public class StocksService : System.Web.Services.WebService
{
    [WebMethod]
    public decimal[] GetStockPrices()
    {
        // Read the XML file into a DataSet
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("~/App_Data/Stocks.xml"));

        // Extract the stock prices from the DataSet
        decimal[] prices = new decimal[3]; 
        prices[0] = Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"]);
        prices[1] = Convert.ToDecimal(ds.Tables[0].Rows[1]["Price"]);
        prices[2] = Convert.ToDecimal(ds.Tables[0].Rows[2]["Price"]);

        // Return an array of prices
        return prices;
    }
}