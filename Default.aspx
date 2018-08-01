<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title></title>
    <style type="text/css">
        .modal-content{
            background-color: #fefefe;
    margin: 5% auto 15% auto; /* 5% from the top, 15% from the bottom and centered */
    border: 1px solid #888;
    width: 20%;
        }
        img.avatar {
    width: 95%;
    /*border-radius: 100%;*/
    
}
        .container {
    padding: 16px;
}
    </style>
    
</head>

<body>

    <form id="form1" runat="server" class="modal-content">


    <div>
        <%--<asp:Button ID="btnShow" runat="server" Text="Show PDF"  OnClick="btnShow_OnClick"/>--%>
        <img src="Pics/10bits.bmp" class="avatar" />
    </div>
        <div class="container">
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Login" />
        </div>
        
    </form>

</body>

</html>

