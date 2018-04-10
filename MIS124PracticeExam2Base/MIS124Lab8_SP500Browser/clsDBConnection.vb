Imports System.Data.SqlClient
Public Class clsDBConnection
    Public Shared Function getConnection() As SqlConnection
        Return New SqlConnection(ConfigurationManager.ConnectionStrings("TAH2077_Products").ConnectionString)
    End Function
End Class
