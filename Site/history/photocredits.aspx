<%@ Page Language="C#" MasterPageFile="~/master/ShareMasterPage.master" AutoEventWireup="true" CodeFile="photocredits.aspx.cs" Inherits="groups_Default"  Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="subPhotoCreditBG"></div>
    <div class="share" style="top: 20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","HISTORY <font size='20'>PHOTO CREDITS</font>");
		        so.write("header1");
	        // ]]>
        </script>

<div class="generalButton" style="top:60px;left:50px;">
            <div>
           
<p style="font-size:12px;">Photo/Video Credits for TOP OF THE ROCK History Video:</p>
            </div>
        


        
            
    </div>

     </div>
</asp:Content>
