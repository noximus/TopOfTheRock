<%@ Page Language="C#" AutoEventWireup="true" CodeFile="maint.aspx.cs" Inherits="admin_maint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
	  <asp:TextBox ID="txtStr" runat="server" Height="125px" TextMode="MultiLine"
		Width="500px"></asp:TextBox>
	  <asp:Button ID="btnGo" runat="server" Text="Go" OnClick=btnGo_Click /><br />
	  <br />
	  <asp:Literal ID="litOut" runat="server"></asp:Literal><br />
	  <br />
	  <asp:GridView ID="grdOut" runat="server">
	  </asp:GridView>
    
    </div>
    </form>
</body>
</html>
