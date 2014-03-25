<%@ Page Language="C#" MasterPageFile="~/master/WelcomeMasterPage.master" AutoEventWireup="true" CodeFile="boomer.aspx.cs" Inherits="welcome_boomer" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="generalButton" style="left:0px;top:2px;">
    <div id="header1" align="center">
    </div>

    <script type="text/javascript">
            // <![CDATA[
	            var so = new SWFObject("<asp:Literal ID="litJSSetFlash" runat="server"></asp:Literal>", "TOTR Nav", "879", "242", "8", "#262626");
	            so.write("header1");
            // ]]>
    </script>

</div>
    </div>
    <div class="hrule" style="top: 229px;">
        
    </div>
    <div class="hrule" style="top: 244px; height: 25px;">
    </div>
    <div class="generalButton" style="top:250px;left:20px;width:400px;">
        <p style="font-size:11px;">Top of the Rock offers its visitors the finest view of the world’s most famous city – your city. Take your place on the observation deck and experience a historic venue with a legendary view. The observation deck is a monument to human achievement – the crown jewel of John D. Rockefeller’s legacy of civic pride. Celebrate New York from its most romantic, pristine summit; celebrate your arrival at the Top of the Rock.<br /><br /></p>
        <p style="font-size:11px;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="ShareClick">Share your rise.</asp:LinkButton>  Post your snapshots and videos for your friends, your family and the world to see.<br /><br /></p>
        <p style="font-size:11px;">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LearnClick">Learn more</asp:LinkButton> about the rich history of the observation deck and the thousands of men and women who built it.</p>
    </div>
    <div class="generalButton" style="top:251px;left:440px;">
        <asp:Image runat="server" id="img_right" SkinId="WelcomeBoomerRight" Width="421" Height="160"/>
     </div>
</asp:Content>

