<%@ Page AutoEventWireup="true" CodeFile="contactForm.aspx.cs"
    Inherits="contact_contactForm" Language="C#" MasterPageFile="~/master/ContactMasterPage.master" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
<link href="/common/forms.css" rel="stylesheet" type="text/css" />
    <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>

		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","FILM AND PHOTO SHOOT FORM");
		        so.write("header1");
	        // ]]>
		</script>
        </div>
        
        <div class="generalButton" style="left:0px;top:80px;">
        <div id="Div1" align="center"></div>
		<table border=0>
		    <tr>
			  <td width=30>&nbsp;</td>
			  <td class="formCell" style="width: 400px" align=left valign=top>
				<label>NAME<br />
				<asp:textbox id="txtName" runat="server" cssclass="formTextField"
				    width="250px"></asp:textbox><br />
				    <br />
				ORGANIZATION / COMPANY<br />
				<asp:textbox id="txtOrganization" runat="server" cssclass="formTextField"
				    width="250px"></asp:textbox><br />
				    <br />
				PHONE NUMBER<br />
				<asp:textbox id="txtPhone" runat="server" cssclass="formTextField"
				    width="250px"></asp:textbox><br />
				    <br />
				FAX NUMBER<br />
				<asp:textbox id="txtFax" runat="server" cssclass="formTextField"
				    width="250px"></asp:textbox><br />
				    <br />
				EMAIL ADDRESS (required)<br />
				<asp:textbox id="txtEmail" runat="server" cssclass="formTextField"
				    width="250px"></asp:textbox><br />
				    <br />
				    WEBSITE<br />
				    <asp:TextBox ID="txtWebsite" runat="server" CssClass="formTextField"
					  Width="250px"></asp:TextBox></label><br>
					  <br>
				PURPOSE OF THE SHOOT<br>
				<asp:textbox id="txtPurpose" runat="server" cssclass="formTextField"
				    width="250px"></asp:textbox>					  
					  </td>
			  <td class="formCell" align=left valign=top nowrap=nowrap>
				DATE(s) OF THE SHOOT<br />
		<table><tr>
		<td valign=bottom nowrap=nowrap>
		    <asp:textbox CssClass="formTextField" id="txtMonth" runat="server" width="25px">MM</asp:textbox>
		    <asp:textbox id="txtDay" runat="server" cssclass="formTextField"
			  width="25px">DD</asp:textbox>
		    <asp:textbox id="txtYear" runat="server" cssclass="formTextField"
			  width="50px">YYYY</asp:textbox>
		</TD>
		<td width=50 align=center>
		    <b>-</B></td>
		<td nowrap=nowrap valign=bottom>
		    <asp:TextBox ID="txtMonth2" runat="server" CssClass="formTextField"
			  Width="25px">MM</asp:TextBox>
		    <asp:TextBox ID="txtDay2" runat="server" CssClass="formTextField"
			  Width="25px">DD</asp:TextBox>
		    <asp:TextBox ID="txtYear2" runat="server" CssClass="formTextField"
			  Width="50px">YYYY</asp:TextBox></td>
		</tr></table>
				<br />
				<asp:DropDownList ID="ddLoadInTime" runat="server">
				    <asp:ListItem>LOAD IN TIME</asp:ListItem>
				    <asp:ListItem>12 midnight</asp:ListItem>
				    <asp:ListItem>1 AM</asp:ListItem>
				    <asp:ListItem>2 AM</asp:ListItem>
				    <asp:ListItem>3 AM</asp:ListItem>
				    <asp:ListItem>4 AM</asp:ListItem>
				    <asp:ListItem>5 AM</asp:ListItem>
				    <asp:ListItem>6 AM</asp:ListItem>
				    <asp:ListItem>7 AM</asp:ListItem>
				    <asp:ListItem>8 AM</asp:ListItem>
				    <asp:ListItem>9 AM</asp:ListItem>
				    <asp:ListItem>10 AM</asp:ListItem>
				    <asp:ListItem>11 AM</asp:ListItem>
				    <asp:ListItem>12 noon</asp:ListItem>
				    <asp:ListItem>2 PM</asp:ListItem>
				    <asp:ListItem>3 PM</asp:ListItem>
				    <asp:ListItem>4 PM</asp:ListItem>
				    <asp:ListItem>5 PM</asp:ListItem>
				    <asp:ListItem>6 PM</asp:ListItem>
				    <asp:ListItem>7 PM</asp:ListItem>
				    <asp:ListItem>8 PM</asp:ListItem>
				    <asp:ListItem>9 PM</asp:ListItem>
				    <asp:ListItem>10 PM</asp:ListItem>
				    <asp:ListItem>11 PM</asp:ListItem>
				</asp:DropDownList>
				&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
				<asp:DropDownList ID="ddLoadOutTime" runat="server">
				    <asp:ListItem>LOAD OUT TIME</asp:ListItem>
				    <asp:ListItem>12 midnight</asp:ListItem>
				    <asp:ListItem>1 AM</asp:ListItem>
				    <asp:ListItem>2 AM</asp:ListItem>
				    <asp:ListItem>3 AM</asp:ListItem>
				    <asp:ListItem>4 AM</asp:ListItem>
				    <asp:ListItem>5 AM</asp:ListItem>
				    <asp:ListItem>6 AM</asp:ListItem>
				    <asp:ListItem>7 AM</asp:ListItem>
				    <asp:ListItem>8 AM</asp:ListItem>
				    <asp:ListItem>9 AM</asp:ListItem>
				    <asp:ListItem>10 AM</asp:ListItem>
				    <asp:ListItem>11 AM</asp:ListItem>
				    <asp:ListItem>12 noon</asp:ListItem>
				    <asp:ListItem>2 PM</asp:ListItem>
				    <asp:ListItem>3 PM</asp:ListItem>
				    <asp:ListItem>4 PM</asp:ListItem>
				    <asp:ListItem>5 PM</asp:ListItem>
				    <asp:ListItem>6 PM</asp:ListItem>
				    <asp:ListItem>7 PM</asp:ListItem>
				    <asp:ListItem>8 PM</asp:ListItem>
				    <asp:ListItem>9 PM</asp:ListItem>
				    <asp:ListItem>10 PM</asp:ListItem>
				    <asp:ListItem>11 PM</asp:ListItem>
				</asp:DropDownList><br />
				<br />
				Equipment list:&nbsp;&nbsp;
				<asp:textbox id="txtEquipmentList" runat="server" cssclass="formTextField"
				    height="30px" textmode="MultiLine" width="200px"></asp:textbox>
				<table>
				    <tr>
					  <td style="width: 100px" valign=top>
						Film <asp:CheckBox ID="chkFilm" runat="server" />
						Photo <asp:checkbox id="chkPhoto" runat="server" />
					  </td>
						<td width=100></td>
					  <td valign=middle>
						APPROXIMATE NUMBER OF<br />
						PEOPLE ON THE SHOOT</td>
					<td width=50></td>
					  <td style="width: 100px" valign=middle>
						<asp:TextBox ID="txtNumPeople" runat="server" CssClass="formTextField"
						    Width="50px"></asp:TextBox></td>
				    </tr>
				</table>
				WHICH VENUE ARE YOU INTERESTED IN?<br />
				<table>
				    <tr>
					  <td valign=top>
						<asp:checkbox id="chkWeather" runat="server"></asp:checkbox>
					  </td>
					  <td>
						Weather Room at<br>
						Top of the Rock</td>
					  <td width=30>
					  </td>
					  <td valign=top>
						<asp:checkbox id="chk620" runat="server"></asp:checkbox>
					  </td>
					  <td valign=top>
						620 Loft &amp; Garden</td>
				    </tr>
				</table>
				<table><tr><td>WILL THERE BE TALENT ON SITE?</td>
				<td><asp:RadioButtonList ID="rbTalent"
				    runat="server" RepeatDirection="Horizontal">
				    <asp:ListItem checked>YES</asp:ListItem>
				    <asp:ListItem>NO</asp:ListItem>
				</asp:RadioButtonList></td></tr></table>
				PLEASE INCLUDE ANY OTHER INFORMATION THAT<BR>WOULD BE HELPFUL FOR
				US TO KNOW<br />

			  <table><tr><td>
				<asp:textbox id="txtOtherInfo" runat="server" cssclass="formTextField"
				    height="50px" textmode="MultiLine" width="250px"></asp:textbox>
			  </td><td valign=bottom>			    
				<asp:imagebutton id="btnSubmit" runat="server" imagealign="Left"
				    imageurl="../App_Themes/Gray/images/submit.png">
</asp:imagebutton>
				</td></tr></table>

			  </td>
		    </tr>
		</table>
	  </div>
</asp:Content>

