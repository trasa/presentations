<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PopupCalendar.aspx.cs" Inherits="PopupCalendar" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses a PopupControlExtender to implement a popup calendar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    Date of Arrival:&nbsp;

    <asp:UpdatePanel ID="DateOfBirthUpdatePanel" UpdateMode="Conditional" RenderMode="Inline" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="Month" runat="server">
                <asp:ListItem Value="Jan">January</asp:ListItem>
                <asp:ListItem Value="Feb">February</asp:ListItem>
                <asp:ListItem Value="Mar">March</asp:ListItem>
                <asp:ListItem Value="Apr">April</asp:ListItem>
                <asp:ListItem Value="May">May</asp:ListItem>
                <asp:ListItem Value="Jun">June</asp:ListItem>
                <asp:ListItem Value="Jul">July</asp:ListItem>
                <asp:ListItem Value="Aug">August</asp:ListItem>
                <asp:ListItem Value="Sep">September</asp:ListItem>
                <asp:ListItem Value="Oct">October</asp:ListItem>
                <asp:ListItem Value="Nov">November</asp:ListItem>
                <asp:ListItem Value="Dec">December</asp:ListItem>
            </asp:DropDownList>&nbsp;
            <asp:TextBox ID="Day" Width="32px" runat="server" />&nbsp;
            <asp:TextBox ID="Year" Width="64px" runat="server" />&nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Image ID="CalendarButton" ImageUrl="~/Images/CalendarIcon.gif" runat="server" />

    <ajaxToolkit:PopupControlExtender ID="CalendarPopupControlExtender" runat="server"
        TargetControlID="CalendarButton" PopupControlID="CalendarPanel" Position="Bottom"
        CommitProperty="ImageAlign" />

    <asp:Panel ID="CalendarPanel" CssClass="popupCalendar" runat="server">
        <asp:UpdatePanel ID="CalendarUpdatePanel" runat="server">
            <contenttemplate>
<asp:Calendar id="MyCalendar" runat="server" Width="200px" Font-Size="8pt" OnSelectionChanged="OnDateSelected" ForeColor="Black" Font-Names="Verdana" DayNameFormat="Shortest" CellPadding="4" BorderColor="#999999" BackColor="White" Height="180px">
<SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True"></SelectedDayStyle>

<TodayDayStyle BackColor="#CCCCCC" ForeColor="Black"></TodayDayStyle>

<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>

<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>

<OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>

<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>

<DayHeaderStyle BackColor="#CCCCCC" Font-Size="7pt" Font-Bold="True"></DayHeaderStyle>

<TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True"></TitleStyle>
</asp:Calendar> 
</contenttemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>