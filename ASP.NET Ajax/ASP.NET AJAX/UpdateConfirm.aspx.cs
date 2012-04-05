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

public partial class UpdateConfirm : System.Web.UI.Page
{
    private static readonly string[] _images =
        {
            "tech_bindings_02.gif",
            "tech_boots_01.gif",
            "tech_outerwear_01.gif",
            "tech_bindings_01.gif"
        };
    
    private static int _index = 0;
    
    protected void OnUpdateButtonClicked(object sender, EventArgs e)
    {
        if (++_index == _images.Length)
            _index = 0;

        TestImage.ImageUrl = "~/Images/Photos/" + _images[_index];
    }
}
