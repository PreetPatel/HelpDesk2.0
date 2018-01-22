<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/HelpDesk.Master" CodeBehind="IssueList.aspx.vb" Inherits="HelpDesk2._0.IssueList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
   
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <table style="float:right">
            <tr>
                <td style="width:10%">

                    <asp:Label ID="Label1" runat="server" Text="Status:"></asp:Label>

                </td>
                <td style="width:10%">

                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"> 
                   
                    </asp:DropDownList>

                </td>
                <td style="width:10%">

                    <asp:Label ID="Label2" runat="server" Text="Priority:"></asp:Label>

                </td>
                <td style="width:10%">

                    <asp:DropDownList ID="ddlPriority" runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
                <td style="width:10%">

                    <asp:Label ID="Label3" runat="server" Text="Issued To:"></asp:Label>

                </td>
                <td style="width:10%">

                    <asp:DropDownList ID="ddlIssued2" runat="server" AutoPostBack="True" style="height: 22px">
                    </asp:DropDownList>

                </td>
            </tr>
        </table>

        
    </section>
    <div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Right" AllowPaging="True" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
<asp:SqlDataSource ID="SqlDataSourceTest" runat="server" ConnectionString="<%$ ConnectionStrings:TrainingConnectionString %>" SelectCommand="SELECT * FROM [Requests]"></asp:SqlDataSource>
</asp:Content>
