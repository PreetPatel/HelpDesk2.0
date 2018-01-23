Public Class Activity
    Inherits System.Web.UI.Page
    Dim dtActivity, dtCaseDetails, dtIssueTo As DataTable
    Dim Caseid As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
   

        Caseid = Request.QueryString("Id")
        If Not Me.IsPostBack Then
            Select_from_DB("Select * from dbo.Requests where CaseID = '" + Caseid + "'", dtCaseDetails)
            lblcaseID1.Text = dtCaseDetails.Rows(0).Item(0).ToString
            lblSubject1.Text = dtCaseDetails.Rows(0).Item(1).ToString
            ddlCategory.Text = dtCaseDetails.Rows(0).Item(2).ToString
            txtDescription.Text = dtCaseDetails.Rows(0).Item(3).ToString
            ddlPriority.Text = dtCaseDetails.Rows(0).Item(4).ToString
            clddate.Visible = False
            lblDueDate.Text = dtCaseDetails.Rows(0).Item(5).ToString
            ddlStatus.Text = dtCaseDetails.Rows(0).Item(6).ToString
            ddlIssuedTo.SelectedValue = dtCaseDetails.Rows(0).Item(7).ToString
            txtLocation.Text = dtCaseDetails.Rows(0).Item(9).ToString

            Select_from_DB("Select Username, FirstName, LastName, FirstName+ ' ' +LastName AS [FullName]from dbo.Users where Role = 'it'", dtIssueTo)
            ddlIssuedTo.DataSource = dtIssueTo
            ddlIssuedTo.DataValueField = "Username"
            ddlIssuedTo.DataTextField = "FullName"
            ddlIssuedTo.DataBind()

            Select_from_DB("Select [ActivityID],[Username],[Timestamp],[Description] from dbo.Activity where CaseID ='" + Caseid + "'", dtActivity)
            gvActivity.DataSource = dtActivity
            gvActivity.DataBind()
        End If
    End Sub

    Protected Sub btnUpdateDate_Click(sender As Object, e As EventArgs) Handles btnUpdateDate.Click
        clddate.Visible = True
    End Sub

    Protected Sub clddate_SelectionChanged(sender As Object, e As EventArgs) Handles clddate.SelectionChanged
        lblDueDate.Text = clddate.SelectedDate
        clddate.Visible = False
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click


        Try
            Insert_to_DB("UPDATE dbo.Requests SET Category = '" + ddlCategory.SelectedValue.ToString + "',Description = '" + txtDescription.Text + "' , Priority = '" + ddlPriority.SelectedValue.ToString + "' ,Status = '" + ddlStatus.SelectedValue.ToString + "',IssuedTo = '" + ddlIssuedTo.SelectedValue.ToString + "' ,Location = '" + txtLocation.Text + "' ,DueDate = '" + clddate.SelectedDate + "' where CaseID = " + Caseid)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
End Class