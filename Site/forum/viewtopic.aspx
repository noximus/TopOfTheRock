<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/master/ForumMasterPage.master" AutoEventWireup="true" CodeFile="viewtopic.aspx.cs" Inherits="forum_viewtopic" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
<script type="text/javascript">
    <!--
    function ValidateForm(){
        if(document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Topic").value == ""){
            alert("Please enter your comment.");
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
<div class="generalButton" style="top:80px;left:50px;text-align:left;">
   
    <p style="font-size:12px;"><b><asp:Literal runat="server" Text="<%$ Resources:Header.Text %>"/>:&nbsp;<asp:Label ID="lbl_Title" runat="server" /></b></p> 
    
    
    <span id="span_Post" runat="server">
        <div id="div5" style="position:absolute;top:10px;left:620px;"></div>
    </span>
        <script type="text/javascript">
        // <![CDATA[
            var so = new SWFObject("../common/swf/button2.swf", "TOTR Nav", "118", "25", "6", "#262626");
            so.addParam("wmode", "transparent");
            so.addVariable("u","javascript:__doPostBack('ctl00$ctl00$ContentBodyHolder$ContentBodyHolder$btn_PostComment','');");
            so.addParam("salign", "tl");
            //so.addVariable("text", "POST COMMENT");
	   <asp:Literal ID="lit_ButtonPostComment" runat="server" meta:resourcekey="PostComment"/>
            so.write("div5");
        // ]]>
    </script>   
    <asp:LinkButton id="btn_PostComment" runat="server" text="Post Comment" OnClick="Post_Click" Visible="false" />
    <br />
    <asp:Panel ScrollBars="Vertical" ID="pnl_Threads" runat="server" Width="800px" Height="260px">
	<p style="margin-bottom:10px;font-size:12px;width:600px;">
        	<asp:Label ID="lbl_Story" runat="server" />
    	</p>

        <asp:Repeater ID="rpt_Threads" runat="server">
            <ItemTemplate>
                <p style="margin-bottom:10px;font-size:11px;">
                    <b><%# Eval("DateCreated")%></b>&nbsp;&nbsp
                    <%# Eval("Topic") %>
                </p>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
<asp:LinkButton id="lb_ChangeCulture" runat="server" OnClick="ChangeCulture_Click"  Visible="false"/>    
    <asp:Panel ID="pnl_PostForm" runat="server" visible="false">
        <br/>
        <asp:TextBox ID="txt_Topic" runat="server" TextMode="MultiLine" Rows="6" Width="362px" />
        <asp:LinkButton id="btn_Comment" runat="server" text="Post Comment" OnClick="PostComment_Click" Visible="false"/>
        
        
        <div id="div6" style="position:absolute;top:200px;left:240px;"></div>
        <script type="text/javascript">
        // <![CDATA[
            var so = new SWFObject("../common/swf/button2.swf", "TOTR Nav", "118", "25", "6", "#262626");
            so.addParam("wmode", "transparent");
            so.addVariable("u","javascript:if(ValidateForm()){__doPostBack('ctl00$ctl00$ContentBodyHolder$ContentBodyHolder$btn_Comment','');}");
            so.addParam("salign", "tl");
            //so.addVariable("text", "POST COMMENT");
	    <asp:Literal ID="lit_ButtonPostComment2" runat="server" meta:resourcekey="PostComment"/>
            so.write("div6");
        // ]]>
    </script>   
        
    </asp:Panel>

</div>
</asp:Content>

