Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clsDBConnection
    Public Shared Function getConnection() As SqlConnection

        'Spiros DB server
        Return New SqlConnection(ConfigurationManager.ConnectionStrings("TAH2077_Products").ConnectionString)

    End Function
End Class
