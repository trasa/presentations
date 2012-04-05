// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

using System;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using AjaxControlToolkit;

[assembly: System.Web.UI.WebResource("DropDownListWatermark.DropDownListWatermarkBehavior.js", "text/javascript")]

namespace DropDownListWatermark
{
    [Designer(typeof(DropDownListWatermarkDesigner))]
    [ClientScriptResource("DropDownListWatermark.DropDownListWatermarkBehavior", "DropDownListWatermark.DropDownListWatermarkBehavior.js")]
    [TargetControlType(typeof(DropDownList))]
    public class DropDownListWatermarkExtender : ExtenderControlBase
    {
        public DropDownListWatermarkExtender()
        {
            EnableClientState = true;
        }
        
        private const string stringWatermarkText = "WatermarkText";

        [ExtenderControlProperty]
        [RequiredProperty()]
        [DefaultValue("")]
        public string WatermarkText
        {
            get
            {
                return GetPropertyStringValue(stringWatermarkText);
            }
            set
            {
                SetPropertyStringValue(stringWatermarkText, value);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //
            // Register script to remove watermark before form is submitted to server
            //
            string key = string.Format(CultureInfo.InvariantCulture, "{0}_onSubmit", ID);
            string script = string.Format(CultureInfo.InvariantCulture, "var o = $find('{0}'); if(o) {{ o._onSubmit(); }}", BehaviorID);
            ScriptManager.RegisterOnSubmitStatement(this, GetType(), key, script);

            //
            // If this is a postback, let the client-side extender know so
            // it can refrain from adding a watermark.
            //
            if (Page.IsPostBack)
                ClientState = "__postback__";
        }
    }
}