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

public partial class AutoRefresh1 : System.Web.UI.Page, ICallbackEventHandler
{
    private static readonly string _script1 =
        "<script type=\"text/javascript\">\n" +
        "function __onCallbackCompleted (result, context)\n" +
        "{{\n" +
        "var args = result.split (';');\n" +
        "var gridView = document.getElementById('{0}');\n" +
        "gridView.rows[1].cells[1].childNodes[0].nodeValue = args[0];\n" +
        "gridView.rows[2].cells[1].childNodes[0].nodeValue = args[1];\n" +
        "gridView.rows[3].cells[1].childNodes[0].nodeValue = args[2];\n" +
        "}}\n" +
        "</script>";

    private static readonly string _script2 =
        "<script type=\"text/javascript\">\n" +
        "window.setInterval (\"{0}\", 5000);\n" +
        "</script>";

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get a callback event reference
        string cbref = ClientScript.GetCallbackEventReference(this, "null",
            "__onCallbackCompleted", "null", true);

        // Register a block of client-side script containing __onCallbackCompleted
        ClientScript.RegisterClientScriptBlock(typeof(Page), "UpdateScript", String.Format(_script1, GridView1.ClientID));

        // Register a block of client-side script that launches an XML-HTTP
        // callback at 5 second intervals
        ClientScript.RegisterStartupScript(typeof(Page), "StartupScript", String.Format(_script2, cbref));
    }

    public void RaiseCallbackEvent(string arg)
    {
        // This space intentionally left blank
    }

    public string GetCallbackResult()
    {
        // Read the XML file into a DataSet
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("~/App_Data/Stocks.xml"));

        // Extract the stock prices from the DataSet
        string amzn = ds.Tables[0].Rows[0]["Price"].ToString();
        string intc = ds.Tables[0].Rows[1]["Price"].ToString();
        string msft = ds.Tables[0].Rows[2]["Price"].ToString();

        // Return a string containing all three stock prices
        // (e.g., "10.0;20.0;30.0")
        return (amzn + ";" + intc + ";" + msft);
    }
}
