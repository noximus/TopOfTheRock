<%@ Page Language="C#" MasterPageFile="~/master/ForumMasterPage.master" AutoEventWireup="true" CodeFile="newtopic.aspx.cs" Inherits="forum_newtopic" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">

    <script type="text/javascript">
    <!--
    function ValidateForm(){
        if(document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Title").value == ""){
            alert("Please enter your topic title.");
            document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Title").focus();
            return false;
        }
        if(document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Topic").value == ""){
            alert("Please enter your topic.");
            document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Topic").focus();
            return false;
        }
        return true;
    }
    -->
    </script>
    
    <div class="share" style="top: 20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        //so.addVariable("text","GLOBAL FORUM");
			<asp:Literal ID="lit_FlashHeader" runat="server" meta:resourcekey="FlashHeader"/>
		        so.write("header1");
	        // ]]>
        </script>     
    </div>
    <div class="generalButton" style="left:500px;top:22px;">
        <div id="DivFlag" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/flagsForum.swf", "TOTR Nav", "350", "40", "8", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addParam("salign", "tl");
		        //so.addVariable("selectFlag","en");
			<asp:Literal ID="lit_FlashCulture" runat="server"/>
		        so.write("DivFlag");
	        // ]]>
        </script>    
    </div>  
	<asp:LinkButton id="lb_ChangeCulture" runat="server" OnClick="ChangeCulture_Click"  Visible="false"/>    
    <div class="generalButton" style="top:140px; left:50px;text-align:left;">
        <div class="storyForm">
        <label><asp:Literal runat="server" Text="<%$ Resources:Header1.Text %>"/><br />
        <asp:TextBox ID="txt_Title" runat="server" Width="362px" MaxLength="500"/>
        </label><br />
        <label><asp:Literal runat="server" Text="<%$ Resources:Header.Text %>"/><br />
        <asp:TextBox ID="txt_Topic" runat="server" TextMode="MultiLine" Rows="4" Width="362px" />
        </label>
            <asp:LinkButton ID="img_Save" runat="server" SkinID="SubmitStory" OnClick="Save_Click" Visible="true"/>
        </div>
        <div id="div5" style="position:absolute;top:160px;left:300px;"></div>
        <script type="text/javascript">
        // <![CDATA[
            var so = new SWFObject("../common/swf/button2.swf", "TOTR Nav", "60", "25", "6", "#262626");
            so.addParam("wmode", "transparent");
            so.addVariable("u","javascript:if(ValidateForm()){__doPostBack('ctl00$ctl00$ContentBodyHolder$ContentBodyHolder$img_Save','');}");
            so.addParam("salign", "tl");
            //so.addVariable("text", "SUBMIT");
	    <asp:Literal ID="lit_ButtonPostTopic" runat="server" meta:resourcekey="Submit"/>
            so.write("div5");
        // ]]>
    </script> 

     </div>
     
</asp:Content>

