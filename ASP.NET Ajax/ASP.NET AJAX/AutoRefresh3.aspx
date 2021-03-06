<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AutoRefresh3.aspx.cs" Inherits="AutoRefresh3" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses a client-side timer and asynchronous Web service calls to refresh a GridView every 5 seconds
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:ScriptManagerProxy ID="StocksWebServiceProxy" runat="server">
        <Services>
            <asp:ServiceReference Path="StocksService.asmx" />
        </Services>
    </asp:ScriptManagerProxy>

    <asp:XmlDataSource ID="XmlDataSource1" Runat="server" DataFile="~/App_Data/Stocks.xml" EnableCaching="False">
    </asp:XmlDataSource>
    <asp:GridView ID="GridView1" Runat="server" DataSourceID="XmlDataSource1" BorderWidth="2px"
        BackColor="White" GridLines="None" CellPadding="3" CellSpacing="1" BorderStyle="Ridge"
        BorderColor="White" AutoGenerateColumns="False">
        <FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
        <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#C6C3C6"></PagerStyle>
        <HeaderStyle ForeColor="#E7E7FF" Font-Bold="True" BackColor="#4A3C8C" HorizontalAlign="Center"></HeaderStyle>
        <Columns>
            <asp:BoundField HeaderText="Symbol" DataField="Symbol" SortExpression="Symbol">
                <ItemStyle Width="96px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Price" DataField="Price" SortExpression="Price">
                <ItemStyle HorizontalAlign="Right" Width="96px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="% Change" SortExpression="Change">
                <ItemStyle HorizontalAlign="Right" Width="96px"></ItemStyle>
                <ItemTemplate>
                    <span style='color: <%# ((string) Eval ("Change")).IndexOf ("-") == -1 ? "black" : "red" %>'><%# Eval ("Change") %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="52-Week Low" DataField="Low" SortExpression="Low">
                <ItemStyle HorizontalAlign="Right" Width="128px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="52-Week High" DataField="High" SortExpression="High">
                <ItemStyle HorizontalAlign="Right" Width="128px"></ItemStyle>
            </asp:BoundField>
        </Columns>
        <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#9471DE"></SelectedRowStyle>
        <RowStyle ForeColor="Black" BackColor="#DEDFDE"></RowStyle>
    </asp:GridView>

    <script type="text/javascript">
    function pageLoad()
    {
        var timer = new Sys.Preview.Timer();
        timer.initialize();
        timer.set_enabled(true);
        timer.set_interval(5000); // 5 seconds
        timer.add_tick(onTick);
    }

    function onTick()
    {
        StocksService.GetStockPrices(onCompleted);
    }

    function onCompleted(result)
    {
        var gridView = $get('ctl00_Main_GridView1');
        gridView.rows[1].cells[1].childNodes[0].nodeValue = result[0].toFixed(1);
        gridView.rows[2].cells[1].childNodes[0].nodeValue = result[1].toFixed(1);
        gridView.rows[3].cells[1].childNodes[0].nodeValue = result[2].toFixed(1);
    }
    </script>
</asp:Content>