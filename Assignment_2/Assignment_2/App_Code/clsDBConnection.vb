Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clsDBConnection

    Public Shared Function getConnection() As SqlConnection

        Return New SqlConnection(ConfigurationManager.ConnectionStrings("TaxReturn2014_Rodger").ConnectionString)

    End Function

End Class
