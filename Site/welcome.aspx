<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/master/WelcomeMasterPage.master" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="welcome" Title="Welcome" %>
<asp:Content ContentPlaceHolderID="ContentBodyHolder" runat="server" ID="bodyHolder">
<div id="intro" style="padding-top:2px;"></div>
    <script type="text/javascript">
        // <![CDATA[
            var so = new SWFObject("common/swf/intro.swf", "TOTR Intro", "879", "440", "8", "#262626");
            so.write("intro");
        // ]]>
    </script>
<span style="display:none;">
<asp:LinkButton ID="img_SkipIt" runat="server" SkinId="SkipIt" OnClick="Skip_Click"/>
<asp:LinkButton ID="img_RockIt" runat="server" SkinId="RockIt" OnClick="SaveSetting_Click" />
</span>

</asp:Content>