<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_AddRestaurant.aspx.cs" Inherits="WebAPIClient.Admin_AddRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin | Add Restaurant</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 165px;
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container">
            <p class="h3 mt-4">Add Restaurant</p>

            <table>
            <tr>
                <td class="auto-style1">Restaurant Name : </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Description&nbsp; :</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Address :</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style1">Contact No :</td>
                <td>
                    <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
            <br />
        <asp:Button class="btn btn-primary mt-3" ID="Btn_Add_Restaurant" runat="server" OnClick="Btn_Add_Restaurant_Click" Text="Add Restaurant" />

            <br />
            <br />
&nbsp;<asp:Label ID="lblStatus" runat="server" class="h5"></asp:Label>
        <br />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#0066FF" NavigateUrl="~/Admin_Home.aspx">Back To Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
