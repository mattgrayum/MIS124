Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class clsProductDB
    Public Shared Function getProduct(ByVal ID As Integer) As clsProduct

        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.Products WHERE [Product ID] = " & ID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)
        Dim product As clsProduct = Nothing
        If dbReader.Read() Then
            product = New clsProduct(dbReader.GetInt64(0), dbReader.GetString(1), dbReader.GetDecimal(2),
                                       dbReader.GetInt32(3), dbReader.GetInt32(4), dbReader.GetInt32(5),
                                       dbReader.GetString(6), dbReader.GetDecimal(7))
        Else
            Throw New ArgumentException("ERROR: SQL103. The Product ID that you entered does not exist in the database." & vbCrLf & vbCrLf &
                                       "Please check your records and enter a valid Product ID")
        End If

        Return product
    End Function
End Class
