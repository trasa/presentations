<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AnimatedMouseOvers.aspx.cs" Inherits="AnimatedMouseOvers" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses AnimationExtenders to animate mouseovers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table cellpadding="4" cellspacing="0" border="2">
        <tr>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="LightSteelBlue">
                <asp:Panel ID="s1" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">1</asp:Panel>
            </td>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="LightGoldenrodYellow">
                <asp:Panel ID="s2" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">2</asp:Panel>
            </td>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="Violet">
                <asp:Panel ID="s3" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">3</asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="AliceBlue">
                <asp:Panel ID="s4" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">4</asp:Panel>
            </td>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="Khaki">
                <asp:Panel ID="s5" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">5</asp:Panel>
            </td>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="LightPink">
                <asp:Panel ID="s6" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">6</asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="Gold">
                <asp:Panel ID="s7" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">7</asp:Panel>
            </td>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="LawnGreen">
                <asp:Panel ID="s8" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">8</asp:Panel>
            </td>
            <td width="150px" height="120px" align="center" valign="middle" bgcolor="silver">
                <asp:Panel ID="s9" Width="50px" Height="40px" Font-Size="32pt" Font-Bold="true" runat="server">9</asp:Panel>
            </td>
        </tr>
    </table>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender1" TargetControlID="s1" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender2" TargetControlID="s2" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender3" TargetControlID="s3" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender4" TargetControlID="s4" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender5" TargetControlID="s5" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender6" TargetControlID="s6" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender7" TargetControlID="s7" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender8" TargetControlID="s8" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender9" TargetControlID="s9" runat="server">
        <Animations>
            <OnMouseOver>
                <Sequence>
                    <Scale ScaleFactor="2.0" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                    <Scale ScaleFactor="0.5" Unit="px" ScaleFont="true" FontUnit="pt" Center="true" Duration="0.2" Fps="20" />
                </Sequence>
            </OnMouseOver>
        </Animations>
    </ajaxToolkit:AnimationExtender>
</asp:Content>