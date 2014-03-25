<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/master/ShareMasterPage.master" AutoEventWireup="true" CodeFile="tellyourstory.aspx.cs" Inherits="share_tellyourstory" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <script type="text/javascript">
    <!--
    function ValidateForm(){
        if(document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Title").value == ""){
            alert("Please enter your story title.");
            document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Title").focus();
            return false;
        }
        if(document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_YouTube").value != ""){
            var str = new String();
            str = document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_YouTube").value;
            if(str.match(/^<object[\s\S]+object>$/g) == null){
                alert("Please enter valid embed YouTube link.");
                document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_YouTube").focus();
                return false;
            }
        }
        if(document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_dd_Category").value == ""){
            alert("Please select category for your story.");
            document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_dd_Category").focus();
            return false;
        }
        if(document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Story").value == ""){
            alert("Please enter your story.");
            document.getElementById("ctl00_ctl00_ContentBodyHolder_ContentBodyHolder_txt_Story").focus();
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
		        so.addVariable("text","TELL YOUR STORY <font size='16'>FROM 70 STORIES UP</font>");
		        so.write("header1");
	        // ]]>
        </script>
        <p style="padding: 10px 50px 10px 50px;">Enter a YouTube* link for your Top of the Rock video or upload your digital photos below to get started. Then, tell us about them by sharing your story. When you’re finished, click “Share My Story” and broadcast your point of view from the Top.</p>
     </div>
     <div class="generalButton" style="top:120px; left:50px;text-align:left;">
        <div class="storyForm">
        <label>CREATE TITLE<br />
        <asp:TextBox ID="txt_Title" runat="server" Width="362px" MaxLength="200"/>
        </label><br />
        <label>ENTER YOUR YouTube LINK <span style="font-size:10px;font-weight:normal;">(OPTIONAL)</span><br />
        <asp:TextBox ID="txt_YouTube" runat="server" Width="362px"  /><br />
        <span style="font-size:10px;font-weight:normal;color:#999999;text-transform:none;">Need help posting your video to YouTube? <a href="http://www.youtube.com/t/help_center" target="_blank">Click here</a> for more information about the site.</span>
        </label><br />
        <label>THEN, TELL US YOUR STORY  </label>
            <asp:TextBox ID="txt_Story" runat="server" TextMode="MultiLine" Rows="4" Width="362px" /><br />
            <p style="width:700px;padding-top:10px;font-size=11px;">Please note that all stories, photographs and videos are subject to review and will be published at the sole discretion of the Top of the Rock management. By making your submission, the author or photographer relinquish all rights and authorize Top of the Rock Management to distribute the information and images to the public without consent from the author or photographer.</p>
        </div>
     </div>
     
     <div class="generalButton" style="top:235px; left:498px;text-align:left;">   
        <div class="storyForm">   
        <label>WHAT BEST DESCRIBES YOUR STORY?</label>  
            <label><asp:DropDownList ID="dd_Category" runat="server" /><br /></label>
        </div>       
     </div>
     
     <div class="generalButton" style="top:285px; left:360px;text-align:left;">
     <asp:ImageButton ID="img_Save" runat="server" SkinID="SubmitStory" OnClick="Save_Click" OnClientClick="return ValidateForm();"/>
     </div>
     
     <div class="generalButton" style="top:200px; left:440px;height:500px; vertical-align:top;"><asp:Image ID="img_Or" runat="server" SkinID="SubmitStoryOr" /></div>
     <div class="generalButton" style="top:138px; left:498px;text-align:left;">
         <div class="storyForm">
             <label>UPLOAD YOUR PHOTO <span style="font-size:10px;font-weight:normal;">(OPTIONAL)</span><br />
                <asp:FileUpload ID="fu_Image" Width="300" runat="server" />
             </label>
         </div>
     </div>

</asp:Content>

