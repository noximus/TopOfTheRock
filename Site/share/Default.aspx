<%@ Page Language="C#"  MasterPageFile="~/master/ShareMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="share_Default" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="share" style="top: 60px;">
        <div class="shareViewPhotoTitleImage" onclick="javascript:window.location.href='http://photos.topoftherocknyc.com'; return false;"><a href="http://photos.topoftherocknyc.com"><img src="/images/share/viewphotos.png" /></a></div>
        <p style="padding-left:75px;width:400px;">
            <asp:Literal runat="server" id="lit_ViewPhotoTitle" />
        </p>
    </div>
    <div class="share" style="top: 180px;">
        <asp:LinkButton runat="server" id="lb_TellStory" OnClick="Tell_Click">
            <div id="header1" align="center"></div>
		    <script type="text/javascript">
	            // <![CDATA[
		            var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		            so.addParam("wmode", "transparent");
		            so.addVariable("u","tell_your_story");
		            so.addVariable("barT","true");
		            so.addVariable("text","<font size='20'>SHARE YOUR STORY</font>");
		            so.write("header1");
	            // ]]>
            </script>
        </asp:LinkButton>
        <p style="padding-left:75px;width:400px;">
            <asp:Literal runat="server" id="lit_ShareStoryTitle" />
        </p>
     </div>
    <div class="share" style="top: 300px;">
        <asp:LinkButton runat="server" id="lb_ViewStory" OnClick="View_Click">
            <div id="header2" align="center"></div>
		    <script type="text/javascript">
	            // <![CDATA[
		            var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		            so.addParam("wmode", "transparent");
		            so.addVariable("u","story_from_top");
		            so.addVariable("barT","true");
		            so.addVariable("text","<font size='20'>STORIES FROM THE TOP</font>");
		            so.write("header2");
	            // ]]>
            </script>
        </asp:LinkButton>
        <p style="padding-left:75px;width:400px;">
            <asp:Literal runat="server" id="lit_StoryFromTitle" />
        </p>
        </div>
    <div class="shareFPhoto" style="top:40px;width:236px;height:156px;color:white;"><img src="../images/share/1.jpg" />These photos will rotate.</div><br />
    <div class="shareFPhoto" style="top:220px;width:236px;height:156px;color:white;"><img src="../images/share/2.jpg" />These photos will rotate.</div><br />
</asp:Content>

