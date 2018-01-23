Imports System.Data
Imports System.Configuration



Public Class IssueList
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim dv As DataView
    Dim dtstat As DataTable
    Dim dtprio As DataTable
    Dim dtissue As DataTable
    Dim dtlist As DataTable
    Dim status As String = ""
    Dim priority As String = ""
    Dim issuedTo As String = ""
    Dim final As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Select_from_DB("Select Distinct [Status] from dbo.Requests", dtstat)
            ddlStatus.DataSource = dtstat
            ddlStatus.DataValueField = "Status"
            ddlStatus.DataTextField = "Status"
            'Dim drow As DataRow = dtstat.NewRow()
            'drow.Item(0) = ""
            'dtstat.Rows.InsertAt(drow, 0)
            ddlStatus.DataBind()
            ddlStatus.Items.Insert(0, New ListItem("All", ""))



            Select_from_DB("Select Distinct [Priority] from dbo.Requests", dtprio)
            ddlPriority.DataSource = dtprio
            ddlPriority.DataValueField = "Priority"
            ddlPriority.DataTextField = "Priority"
            'ddlPriority.Items.Insert(0, New ListItem(String.Empty, String.Empty))
            'ddlPriority.SelectedIndex = 0
            ddlPriority.DataBind()
            ddlPriority.Items.Insert(0, New ListItem("All", ""))

            Select_from_DB("Select Distinct [IssuedTo] from dbo.Requests", dtissue)
            ddlIssued2.DataSource = dtissue
            ddlIssued2.DataValueField = "IssuedTo"
            ddlIssued2.DataTextField = "IssuedTo"
            'ddlIssued2.Items.Insert(0, New ListItem(String.Empty, String.Empty))
            'ddlIssued2.SelectedIndex = 0
            ddlIssued2.DataBind()
            ddlIssued2.Items.Insert(0, New ListItem("All", ""))

            Dim dtlist As DataTable = GetData()
            gvIssueList.DataSource = dtlist
            gvIssueList.DataBind()

        End If



    End Sub



    Protected Sub ddlStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStatus.SelectedIndexChanged
        status = ddlStatus.SelectedItem.Value.ToString

        Session("Status") = status
        ' GridView1.DataSource = dt
        Dim dt As New DataTable
        final = ConcatenateRequest(Session("Status"), Session("Priority"), Session("IssuedTo"))
        Select_from_DB("Select * from dbo.Requests " + final, dt)
        gvIssueList.DataSource = dt
        gvIssueList.DataBind()
    End Sub


    Protected Sub ddlPriority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPriority.SelectedIndexChanged
        priority = ddlPriority.SelectedItem.Value
        Session("Priority") = priority
        ' GridView1.DataSource = dt
        Dim dt As New DataTable

        final = ConcatenateRequest(Session("Status"), Session("Priority"), Session("IssuedTo"))
        Select_from_DB("Select * from dbo.Requests " + final, dt)

        gvIssueList.DataSource = dt
        gvIssueList.DataBind()
    End Sub


    Protected Sub ddlIssued2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlIssued2.SelectedIndexChanged
        issuedTo = ddlIssued2.SelectedItem.Value
        Session("IssuedTo") = issuedTo
        ' GridView1.DataSource = dt
        Dim dt As New DataTable
        final = ConcatenateRequest(Session("Status"), Session("Priority"), Session("IssuedTo"))

        Select_from_DB("Select * from dbo.Requests " + final, dt)

        gvIssueList.DataSource = dt
        gvIssueList.DataBind()
    End Sub

    Private Sub gvIssueList_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvIssueList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvIssueList, "Select$" & e.Row.RowIndex)
            e.Row.Attributes("style") = "cursor:pointer"
        End If
    End Sub

   
    Protected Sub gvIssueList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvIssueList.SelectedIndexChanged
        Dim id As String = gvIssueList.SelectedRow.Cells(0).Text.ToString
        Response.Redirect("~/Users/Activity.aspx?Id=" + id)
    End Sub
End Class