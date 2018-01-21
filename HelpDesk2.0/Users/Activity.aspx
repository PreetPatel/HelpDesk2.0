<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Login.Master" CodeBehind="Activity.aspx.vb" Inherits="HelpDesk2._0.Activity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">y
    <style>
        .div_left {
            float: left;
            width:30%;
            
        }
        .div_right {
            float: right;
            width: 70%;
        }

    </style>

    <style type="text/css">
        .div_left {
            height: 64px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="div_left">
        <table">
            <tr>
                <asp:Label ID="lblActivity" runat="server" Text="Activity Description"></asp:Label>
            </tr>
            <tr>
                <asp:TextBox ID="txtActivity" runat="server" TextMode="MultiLine" Width="400px" Height="400px"></asp:TextBox>
            </tr>
            <tr>
                <asp:Button ID="btnActivity" runat="server" Text="Add Activity" />
            </tr>

        </table>

    </div>

    <div class="div_right">


    </div>

</asp:Content>
