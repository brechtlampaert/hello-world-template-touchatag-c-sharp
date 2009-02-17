<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Createedit.aspx.cs" Inherits="Createedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <TABLE>
    <TR>
        <TD><asp:label runat="server">Your name</asp:label></TD>
        <TD><asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox></TD>
    </TR>
    <TR>
        <TD colspan="2">
            <asp:Button ID="SubmitButton" runat="server" Text="Enter" 
                onclick="SubmitButton_Click" /></TD>
    </TR>
</TABLE>  
    </div>
    </form>
</body>
</html>
