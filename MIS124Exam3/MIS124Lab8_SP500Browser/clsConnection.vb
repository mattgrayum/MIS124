Imports System.Data.SqlClient
Public Class clsConnection
    Public Shared Function getConnection() As SqlConnection
        'This is a connection to my office database.
        'Note that this is NOT the same database that we used in the previous lab

        'The line below connects without the Web.config settings - not the best idea in most cases
        'Return New SqlConnection("Data Source=TAH2077-2\SQLEXPRESS;Initial Catalog=DowIndustrialsSQL;User ID=MIS_Student;Password=cba")

        'The line below connects using the Web.config settings - the best idea in most cases
        Return New SqlConnection(ConfigurationManager.ConnectionStrings("TAH2077_DowStocks").ConnectionString)
    End Function
End Class
