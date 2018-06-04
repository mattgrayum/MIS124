Imports System.Data.SqlClient


Public Class DowStockDB

    Private Shared Function getConnection() As SqlConnection
        Return New SqlConnection("Data Source=130.86.61.134\TAH2077OFFICE; Initial Catalog=DowStocks; User ID=MIS;Password=***")
    End Function

    Public Shared Function getDowStock(ByVal strTicker As String) As clsDowStock
        Dim connection As SqlConnection = getConnection()
        Dim strSelectStatement As String = "SELECT StockName, DivShare, Ticker " _
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
            Throw New ArgumentException("The stock ticker that you entered does not exist in the database." & vbCrLf & vbCrLf & _
                                       "Please check your records and type a valid stock ticker")
        End If
        connection.Close()
        Return myDowStock
    End Function

    Public Shared Function deleteDowStock(ByVal strTicker As String) As Integer
        Dim connection As SqlConnection = getConnection()
        Dim strDeleteStatement As String = "DELETE FROM [DowStocks].[dbo].[tblDowStocks] " _
                                            & "WHERE Ticker='" & strTicker & "'"
        Dim command As New SqlCommand(strDeleteStatement, connection)

        Try
            connection.Open()
            Return command.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function insertDowStock(ByRef stock As clsDowStock) As Integer
        Dim connection As SqlConnection = getConnection()
        Dim myStock As clsDowStock = stock
        Dim strInsertStatement As String = "INSERT INTO [DowStocks].[dbo].[tblDowStocks] (Ticker, StockName, DivShare) " _
                                            & "VALUES ('" & myStock.Ticker & "', '" _
                                            & myStock.StockName & "', " _
                                            & myStock.Dividend & ");"
        Dim command As New SqlCommand(strInsertStatement, connection)

        Try
            connection.Open()
            Return command.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function updatetDowStock(ByRef stock As clsDowStock) As Integer
        'write your implementation below
        'syntax is: UPDATE table_name SET column1=value1,column2=value2,...WHERE some_column=some_value;

        Return 0
    End Function

End Class
