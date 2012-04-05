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
using System.Web.Script.Serialization;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public partial class Json : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Point p = new Point(100, 200);
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string json = jss.Serialize(p);
        JsonOutput.Text = HttpUtility.HtmlEncode (json);

        MemoryStream ms = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(p.GetType());
        xs.Serialize(ms, p);
        string xml = new ASCIIEncoding().GetString(ms.ToArray());
        XmlOutput.Text = HttpUtility.HtmlEncode (xml);
    }
}
