Imports Microsoft.VisualBasic

Public Class clsDBConnection
    Public Shared Function getConnection() As Data.SqlClient.SqlConnection
        Return New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("TaxReturn2014_Rodger").ConnectionString)
    End Function
End Class
