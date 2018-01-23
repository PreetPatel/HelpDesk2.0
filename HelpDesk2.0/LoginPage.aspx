<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/HelpDesk.Master" CodeBehind="LoginPage.aspx.vb" Inherits="HelpDesk2._0.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table>
        <tr>
            <td>
                <asp:Label ID="lblusername" runat="server" Text="Username"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPass" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td class="auto-style1">

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpass" ErrorMessage="Password is required" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button ID="btnLog" runat="server" Text="Login" />
            </td>
            <td class="auto-style1">

            </td>
        </tr>

    </table>

</asp:Content>
