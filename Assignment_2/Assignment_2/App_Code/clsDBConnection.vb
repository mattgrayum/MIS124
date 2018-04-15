Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clsDBConnection

    Public Shared Function getConnection() As SqlConnection

        'local DB
        'Return New SqlConnection(ConfigurationManager.ConnectionStrings("TaxReturn2014_Rodger").ConnectionString)

        'Spiros DB server
        Return New SqlConnection(ConfigurationManager.ConnectionStrings("TaxReturn2014ConnectionString").ConnectionString)


    End Function

End Class
