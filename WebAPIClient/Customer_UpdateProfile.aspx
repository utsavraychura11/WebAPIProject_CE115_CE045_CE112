﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_UpdateProfile.aspx.cs" Inherits="WebAPIClient.Customer_UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile | Customer</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div>
           <p class="h3 mt-4">Update Profile</p>

            <table>
            <tr>
                <td class="auto-style2">Name : </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email : </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Contact No :</td>
                <td>
                    <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            
        </table>
           <br />
        <asp:Button class="btn btn-primary mt-3" ID="Btn_Add_Restaurant" runat="server" OnClick="Btn_Add_Restaurant_Click" Text="Update" />

        &nbsp;&nbsp;&nbsp;

        <asp:Label ID="lblStatus" runat="server" class="h5"></asp:Label>
        <br />
        <br />

            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#0066FF" NavigateUrl="~/Customer_Home.aspx">Back To Home</asp:HyperLink>
       </div>
    </form>
</body>
</html>
