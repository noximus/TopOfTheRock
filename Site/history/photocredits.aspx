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
           
<p style="font-size:12px;">Photo/Video Credits for TOP OF THE ROCK History Video:</p><p style="font-size:12px;padding-top:10px;">Rockefeller Group Inc. (RGI)</p><p style="font-size:12px;padding-top:10px;">Chicago Daily News negatives collection, <br />DN-0003451. Courtesy of the Chicago Historical Society.</p><p style="font-size:12px;padding-top:10px;">Beauline Media Inc.</p><p style="font-size:12px;padding-top:10px;">*Paul Warchol </p><p style="font-size:12px;padding-top:10px;">*Bart Barlow</p>
            </div>
        


        
            
    </div>

     </div>
</asp:Content>

