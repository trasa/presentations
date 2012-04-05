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

public partial class PopupCalendar : System.Web.UI.Page
{
    protected void OnDateSelected(object sender, EventArgs e)
    {
        DateTime date = MyCalendar.SelectedDate;
        Month.SelectedIndex = date.Month - 1;
        Day.Text = date.Day.ToString();
        Year.Text = date.Year.ToString();

        CalendarPopupControlExtender.Commit(String.Empty);
        DateOfBirthUpdatePanel.Update();
    }
}
