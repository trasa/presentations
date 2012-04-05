<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AutoRefresh2.aspx.cs" Inherits="AutoRefresh2" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page combines an UpdatePanel with a TimerControl to refresh a GridView every 5 seconds
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <!-- Timer fires Tick event every 5 seconds -->
    <asp:TimerControl runat="server" Interval="5000" ID="Timer" OnTick="Timer_Tick" />

    <!-- UpdatePanel updates content in response to Tick events -->
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
        </Triggers> 
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>