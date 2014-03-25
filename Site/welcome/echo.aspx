<%@ Page Language="C#" MasterPageFile="~/master/WelcomeMasterPage.master" AutoEventWireup="true" CodeFile="echo.aspx.cs" Inherits="welcome_echo" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="generalButton" style="left: 0px; top: 2px;">
	  <div id="header1" align="center">
	  </div>

	  <script type="text/javascript">
            // <![CDATA[
	            var so = new SWFObject("<asp:Literal ID="litJSSetFlash" runat="server"></asp:Literal>", "TOTR Nav", "879", "242", "8", "#262626");
	            so.write("header1");
            // ]]>
	  </script>

    </div>

    <div class="hrule" style="top: 229px;">
    </div>
    <div class="hrule" style="top: 244px; height: 25px;">
    </div>
    <div class="generalButton" style="top:270px;left:20px;width:400px;">
       <p style="margin-top:5px; font-size:11px;">
	Top of the Rock is the best place to see New York like no one ever has before: through your eyes. Check out the latest technology in our multimedia exhibits, take a ride on our high-speed vertical shuttle, and then take your place above the city. From our crystal clear, glass paneled deck, you can see from here to the future.

<br /><br /></p>

<p style="font-size:11px;">It’s a great spot for a night out. It’s the perfect spot for a night out with someone you love.</p>
    </div>
    
    <div class="generalButton" style="top:264px;left:440px;width:465px;">
        <p><asp:Image runat="server" ID="img_Right" SkinId="WelcomeEchoRight" Width="367" Height="148"/></p>
        
    </div>
</asp:Content>

