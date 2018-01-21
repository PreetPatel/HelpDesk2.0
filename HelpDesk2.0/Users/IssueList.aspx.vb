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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        Select_from_DB("Select Distinct [Status] from dbo.Requests", dtstat)
        ddlStatus.DataSource = dtstat
        ddlStatus.DataValueField = "Status"
        ddlStatus.DataTextField = "Status"
        'Dim drow As DataRow = dtstat.NewRow()
        'drow.Item(0) = ""
        'dtstat.Rows.InsertAt(drow, 0)
        ddlStatus.DataBind()

        Select_from_DB("Select Distinct [Priority] from dbo.Requests", dtprio)
        ddlPriority.DataSource = dtprio
        ddlPriority.DataValueField = "Priority"
        ddlPriority.DataTextField = "Priority"
        'ddlPriority.Items.Insert(0, New ListItem(String.Empty, String.Empty))
        'ddlPriority.SelectedIndex = 0
        ddlPriority.DataBind()

        Select_from_DB("Select Distinct [IssuedTo] from dbo.Requests", dtissue)
        ddlIssued2.DataSource = dtissue
        ddlIssued2.DataValueField = "IssuedTo"
        ddlIssued2.DataTextField = "IssuedTo"
        'ddlIssued2.Items.Insert(0, New ListItem(String.Empty, String.Empty))
        'ddlIssued2.SelectedIndex = 0
        ddlIssued2.DataBind()

        If Not Me.IsPostBack Then
            Dim dtlist As DataTable = GetData()
            GridView1.DataSource = dtlist
            GridView1.DataBind()
        End If



    End Sub



    Protected Sub ddlStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStatus.SelectedIndexChanged
        Dim status As String = ddlStatus.SelectedItem.Value
        ' GridView1.DataSource = dt
        Dim dt As New DataTable
        Select_from_DB("Select * from dbo.Requests where Status ='" + status + "'", dt)
        Dim dv As New DataView
        dv = dt.DefaultView

        If Not String.IsNullOrEmpty(status) Then
            dv.RowFilter = "Status = '" & status & "'"
        End If
        GridView1.DataSource = dv
        GridView1.DataBind()

    End Sub

   
End Class