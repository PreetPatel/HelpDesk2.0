Imports System.Data.SqlClient

Module Module1
    Sub Insert_to_DB(ByVal Query As String)
        Dim constr As String = ConfigurationManager.ConnectionStrings("TrainingConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(Query, con)

                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

    End Sub

    Sub Select_from_DB(ByVal Query As String, ByRef dt As System.Data.DataTable)
        Dim constr As String = ConfigurationManager.ConnectionStrings("TrainingConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlDataAdapter(Query, con)

                dt = New System.Data.DataTable
                cmd.Fill(dt)
                con.Close()
                con.Dispose()

            End Using
        End Using

    End Sub

    Function GetData() As DataTable
        Dim dt1 As New DataTable()
        Select_from_DB("Select * from dbo.Requests", dt1)
        Return dt1
    End Function

    Function ConcatenateRequest(ByRef status As String, ByRef priority As String, ByRef issuedTo As String) As String
        Dim statusMessage As String = ""
        Dim priorityMessage As String = ""
        Dim issuedToMessage As String = ""
        Dim where As String = ""
        Dim done As Boolean = False

        If Not status = "" Or Not priority = "" Or issuedTo = "" Then
            where = "Where "
        End If

        If Not status = "" Then
            statusMessage = "Status = '" + status + "'"
            done = True
        End If
        If Not priority = "" Then
            If done Then
                priorityMessage = " AND "
            End If
            priorityMessage = priorityMessage + "Priority = '" + priority + "'"
            done = True
        End If
        If Not issuedTo = "" Then
            If done Then
                issuedToMessage = " AND "
            End If
            issuedToMessage = issuedToMessage + "IssuedTo = '" + issuedTo + "'"
        End If
        Dim final As String = where + statusMessage + priorityMessage + issuedToMessage
        final.TrimEnd()
        If final.Substring(final.Length - 5) = "Where " Then
            final = final.Remove(final.Length - 6)
        End If
        MsgBox(final.Substring(5))
        Return final
    End Function

End Module
