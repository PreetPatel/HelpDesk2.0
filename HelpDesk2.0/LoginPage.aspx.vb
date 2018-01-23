Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Security.Cryptography

Public Class LoginPage
    Inherits System.Web.UI.Page

    Dim ds As DataSet
    Dim dv As DataView
    Dim dt As DataTable
    Dim salt, hashPasword, checkPassword As String

    Private Function StringtoMD5(ByVal Content As String) As String
        Dim M5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim ByteString() As Byte = System.Text.Encoding.ASCII.GetBytes(Content)
        ByteString = M5.ComputeHash(ByteString)
        Dim FinalString As String = Nothing
        For Each bt As Byte In ByteString
            FinalString &= bt.ToString("x2")
        Next
        Return FinalString
    End Function




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click

        Try
            Dim username As String
            username = txtUsername.Text
            username = username.ToLower
            dt = New System.Data.DataTable
            Dim role As String
            Select_from_DB("Select [Password],[Salt],[Role] from dbo.Users where Username = '" + username + "'", dt)

            hashPasword = dt.Rows(0).Item(0).ToString
            salt = dt.Rows(0).Item(1).ToString
            role = dt.Rows(0).Item(2).ToString
            checkPassword = txtpass.Text + salt
            checkPassword = StringtoMD5(checkPassword)



            If checkPassword = hashPasword Then
                Session("Username") = username
                Session("Role") = role
                If Session("Role") = "user" Then
                    Response.Redirect("~/Users/IssueList.aspx")
                ElseIf Session("Role") = "it" Then
                    Response.Redirect("~/Users/IssueList.aspx")
                
                End If

            Else
                Dim errorMsg As String = "Username or password doesn't match"
                ClientScript.RegisterStartupScript([GetType](), "alert", (Convert.ToString("alert('") & errorMsg) + "');", True)
            End If




        Catch ex As Exception

            ClientScript.RegisterStartupScript([GetType](), "alert", (Convert.ToString("alert('") & ex.Message) + "');", True)
        End Try

    End Sub
End Class