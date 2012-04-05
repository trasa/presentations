<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ToolkitAnimation.aspx.cs" Inherits="ToolkitAnimation" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to "explode" images using the ASP.NET AJAX Control Toolkit's AnimationExtender control
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Image id="Balloon1" ImageUrl="~/Images/balloon.gif" runat="server"
        style="position: absolute; left: 320px; top: 260px; width: 74px; height: 110px" />
    <asp:Image id="Balloon2" ImageUrl="~/Images/balloon.gif" runat="server"
        style="position: absolute; left: 340px; top: 400px; width: 74px; height: 110px" />
    <asp:Image id="Balloon3" ImageUrl="~/Images/balloon.gif" runat="server"
        style="position: absolute; left: 430px; top: 200px; width: 74px; height: 110px" />
    <asp:Image id="Balloon4" ImageUrl="~/Images/balloon.gif" runat="server"
        style="position: absolute; left: 420px; top: 360px; width: 74px; height: 110px" />
    <asp:Image id="Balloon5" ImageUrl="~/Images/balloon.gif" runat="server"
        style="position: absolute; left: 520px; top: 280px; width: 74px; height: 110px" />

    <ajaxToolkit:AnimationExtender ID="AnimationExtender1" TargetControlID="Balloon1" Runat="server">
        <Animations>
            <OnClick>
                <Sequence>
                    <Parallel Duration="0.2" Fps="40">
                        <Scale ScaleFactor="8" Unit="px" Center="true" />
                        <FadeOut />
                    </Parallel>
                    <ScriptAction Script="javascript:removeBalloon('ctl00_Main_Balloon1');" />
                </Sequence>
            </OnClick>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender2" TargetControlID="Balloon2" Runat="server">
        <Animations>
            <OnClick>
                <Sequence>
                    <Parallel Duration="0.2" Fps="40">
                        <Scale ScaleFactor="8" Unit="px" Center="true" />
                        <FadeOut />
                    </Parallel>
                    <ScriptAction Script="javascript:removeBalloon('ctl00_Main_Balloon2');" />
                </Sequence>
            </OnClick>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender3" TargetControlID="Balloon3" Runat="server">
        <Animations>
            <OnClick>
                <Sequence>
                    <Parallel Duration="0.2" Fps="40">
                        <Scale ScaleFactor="8" Unit="px" Center="true" />
                        <FadeOut />
                    </Parallel>
                    <ScriptAction Script="javascript:removeBalloon('ctl00_Main_Balloon3');" />
                </Sequence>
            </OnClick>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender4" TargetControlID="Balloon4" Runat="server">
        <Animations>
            <OnClick>
                <Sequence>
                    <Parallel Duration="0.2" Fps="40">
                        <Scale ScaleFactor="8" Unit="px" Center="true" />
                        <FadeOut />
                    </Parallel>
                    <ScriptAction Script="javascript:removeBalloon('ctl00_Main_Balloon4');" />
                </Sequence>
            </OnClick>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <ajaxToolkit:AnimationExtender ID="AnimationExtender5" TargetControlID="Balloon5" Runat="server">
        <Animations>
            <OnClick>
                <Sequence>
                    <Parallel Duration="0.2" Fps="40">
                        <Scale ScaleFactor="8" Unit="px" Center="true" />
                        <FadeOut />
                    </Parallel>
                    <ScriptAction Script="javascript:removeBalloon('ctl00_Main_Balloon5');" />
                </Sequence>
            </OnClick>
        </Animations>
    </ajaxToolkit:AnimationExtender>

    <script type="text/javascript">
    function removeBalloon(id)
    {
        var image = $get(id);
        image.parentNode.removeChild(image);  // Remove the image
    }
    </script>
</asp:Content>