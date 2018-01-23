<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Login.Master" CodeBehind="Activity.aspx.vb" Inherits="HelpDesk2._0.Activity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .div_top {
            width: auto;
            border: 10px solid double;
            padding: 25px;
            margin: 25px;
            
            
        }
        .div_bottom {
             
            border: 10px solid double;
            padding: 25px;
            margin: 25px;
            width: auto;
        }

        

    </style>

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="div_top">
        <section>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblcaseID" runat="server" Text="Case Id:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblcaseID1" runat="server" Text="___________ "></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblSubject" runat="server" Text="Subject:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSubject1" runat="server" Text="__________"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server">
                            <asp:ListItem>Desktop</asp:ListItem>
                            <asp:ListItem>Laptop</asp:ListItem>
                            <asp:ListItem>Printer</asp:ListItem>
                            <asp:ListItem>Network</asp:ListItem>
                            <asp:ListItem>ERP</asp:ListItem>
                            <asp:ListItem>Applications</asp:ListItem>
                            <asp:ListItem>Software</asp:ListItem>
                            <asp:ListItem>Server</asp:ListItem>
                            <asp:ListItem>Telephones</asp:ListItem>
                            <asp:ListItem>CCTV</asp:ListItem>
                            <asp:ListItem>General</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem>Open</asp:ListItem>
                            <asp:ListItem>In Progress</asp:ListItem>
                            <asp:ListItem>On Hold</asp:ListItem>
                            <asp:ListItem>Closed</asp:ListItem>
                            <asp:ListItem>Suspended</asp:ListItem>
                            <asp:ListItem>Resolved</asp:ListItem>
                            <asp:ListItem>Cancelled</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblIssuedTo" runat="server" Text="Issued To:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIssuedTo" runat="server"></asp:DropDownList>
                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblTargetDate" runat="server" Text="Target Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDueDate" runat="server" Text="-"></asp:Label>
                        <asp:Button ID="btnUpdateDate" runat="server" Text="Change" UseSubmitBehavior="False" CausesValidation="False" />
                        <asp:Calendar ID="clddate" runat="server"></asp:Calendar>
                    </td>
                    <td>
                        <asp:Label ID="lblLocation" runat="server" Text="Location:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblPriority" runat="server" Text="Priority: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPriority" runat="server">
                            <asp:ListItem>High</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>Low</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    

                </tr>

                <tr>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update"/>
                </tr>
            </table>
        </section>

       <%-- <asp:GridView ID="gvCaseDetails" runat="server" AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        </asp:GridView>--%>
        

    </div>

    <div class="div_bottom" >


        <asp:GridView ID="gvActivity" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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

</asp:Content>
