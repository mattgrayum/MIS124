Imports System.Data.SqlClient


Public Class clsDowStockDB

    Public Shared Function getDowStock(ByVal strTicker As String) As clsDowStock
        Dim connection As SqlConnection = clsConnection.getConnection
        Dim strSelectStatement As String = "SELECT StockName, [P E_Ratio], Ticker " _
                                            & " FROM [DowStocks].[dbo].[tblDowStocks] WHERE Ticker ='" & strTicker & "'"
        Dim command As New SqlCommand(strSelectStatement, connection)
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader(CommandBehavior.SingleRow)

        Dim myDowStock As clsDowStock

        If reader.Read Then
            'There are 2 ways to program the read function:

            'OPTION 1:
            'myDowStock = New DowStock(strTicker, _
            '                 reader("StockName").ToString.Trim, _
            '                 CDbl(reader("DivShare")))

            'OPTION 2:
            myDowStock = New clsDowStock(strTicker, _
                             reader.GetString(0).Trim, _
                             CDbl(reader.GetDecimal(1)))
        Else
            Throw New ArgumentException("ERROR: SQL103. The stock ticker that you entered does not exist in the database." & vbCrLf & vbCrLf & _
                                       "Please check your records and type a valid stock ticker.")
        End If
        connection.Close()
        Return myDowStock
    End Function

End Class
