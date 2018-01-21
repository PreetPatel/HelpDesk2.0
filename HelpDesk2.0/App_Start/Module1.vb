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



End Module
