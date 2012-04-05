<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ClientAnimation.aspx.cs" Inherits="ClientAnimation" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to "explode" images using PreviewGlitz.js's animation classes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Name="PreviewGlitz.js" Assembly="Microsoft.Web.Preview" />
        </Scripts>
    </asp:ScriptManagerProxy>

    <img id="Balloon1" src="Images/balloon.gif" onclick="javascript:popBalloon('Balloon1');"
        style="position: absolute; left: 320px; top: 260px; width: 74px; height: 110px" />
    <img id="Balloon2" src="Images/balloon.gif" onclick="javascript:popBalloon('Balloon2');"
        style="position: absolute; left: 340px; top: 400px; width: 74px; height: 110px" />
    <img id="Balloon3" src="Images/balloon.gif" onclick="javascript:popBalloon('Balloon3');"
        style="position: absolute; left: 430px; top: 200px; width: 74px; height: 110px" />
    <img id="Balloon4" src="Images/balloon.gif" onclick="javascript:popBalloon('Balloon4');"
        style="position: absolute; left: 420px; top: 360px; width: 74px; height: 110px" />
    <img id="Balloon5" src="Images/balloon.gif" onclick="javascript:popBalloon('Balloon5');"
        style="position: absolute; left: 520px; top: 280px; width: 74px; height: 110px" />

    <script type="text/javascript">
    var _scaleFactor = 8; // Modify this number to change the scale factor
    var _image, _animation;
    
    function popBalloon(id)
    {
        if (_animation != null)
            return; // Prevent concurrent animations

        _image = $get(id);
        var width = parseFloat(_image.style.width);
        var height = parseFloat(_image.style.height);
        var x = parseFloat(_image.style.left);        
        var y = parseFloat(_image.style.top);        

        //
        // Use a CompositeAnimation object to "explode" the image by
        // simultaneously scaling, moving, and fading it.
        //
        var a1 = new Sys.Preview.UI.Effects.NumberAnimation();
        a1.set_target(_image);
        a1.set_property('style');
        a1.set_propertyKey('width');
        a1.set_startValue(width);
        a1.set_endValue(width * _scaleFactor);

        var a2 = new Sys.Preview.UI.Effects.NumberAnimation();
        a2.set_target(_image);
        a2.set_property('style');
        a2.set_propertyKey('height');
        a2.set_startValue(height);
        a2.set_endValue(height * _scaleFactor);

        var a3 = new Sys.Preview.UI.Effects.NumberAnimation();
        a3.set_target(_image);
        a3.set_property('style');
        a3.set_propertyKey('left');
        a3.set_startValue(x);
        a3.set_endValue(x - (width * (_scaleFactor - 1)) / 2);

        var a4 = new Sys.Preview.UI.Effects.NumberAnimation();
        a4.set_target(_image);
        a4.set_property('style');
        a4.set_propertyKey('top');
        a4.set_startValue(y);
        a4.set_endValue(y - (height * (_scaleFactor - 1)) / 2);

        var a5 = new Sys.Preview.UI.Effects.FadeAnimation();
        a5.set_target(new Sys.Preview.UI.Image(_image));
        a5.set_effect (Sys.Preview.UI.Effects.FadeEffect.FadeOut);

        _animation = new Sys.Preview.UI.Effects.CompositeAnimation();
        _animation.get_animations().add(a1);
        _animation.get_animations().add(a2);
        _animation.get_animations().add(a3);
        _animation.get_animations().add(a4);
        _animation.get_animations().add(a5);
        _animation.set_duration(0.2);
        _animation.set_fps(40);
        _animation.play();

        //
        // Because the animation classes in PreviewScript.js do NOT fire end
        // events (even though you can register end handlers), manually set a
        // timer to fire after one second so we can remove the image from the
        // DOM once the animation is complete.
        //
        var timer = new Sys.Preview.Timer();
        timer.initialize();
        timer.set_enabled(true);
        timer.set_interval(400);
        timer.add_tick(removeBalloon);
    }

    function removeBalloon(sender)
    {
        if (!_animation.get_isPlaying())
        {
            sender.set_enabled(false);              // Disable the timer
            _image.parentNode.removeChild(_image);  // Remove the image
            _animation = null;
        }
    }
    </script>
</asp:Content>