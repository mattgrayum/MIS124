Imports System.Data.SqlClient


Public Class clsDowStockDB

    Public Shared Function getStock(ByVal strTicker As String) As clsDowStock
        'TODO:
        '1. Call the getConnection function from the clsConnection class and get a sqlConnection object
        '2. Create a string with the following syntax: "SELECT StockName, DivShare, Ticker FROM [DowIndustrialsSQL].[dbo].[tblDowStocks] WHERE Ticker ='" & strTicker & "'"
        '   Notice the single quotes in the statement above
        '3. Create a SqlCommand object with the SQL statment of step 2 and connection of step 1
        '4. Open the connection
        '5. Execute the Sqlcommand object's Reader 
        '6. Read data from the reader
        '7. Put the data read from the reader into a clsDowStock object
        '   There are 2 ways to program the read function:
        '   OPTION 1:
        '      myDowStock = New DowStock(strTicker, _
        '                   reader("StockName").ToString.Trim, _
        '                   CDbl(reader("DivShare")))
        '    OPTION 2:
        '      myDowStock = New clsDowStock(strTicker, _
        '                 reader.GetString(0).Trim, _
        '                 CDbl(reader.GetDecimal(1)))
        '8. If no data is found throw and exception like 
        '       Throw New ArgumentException("The stock ticker that you entered does not exist in the database." & vbCrLf & vbCrLf & _
        '                            "Please check your records and type a valid stock ticker")
        Return New clsDowStock("Sample Ticker", "Sample Stock Name", 3.5)

    End Function

    Public Shared Function updateDowStock(ByRef stock As clsDowStock) As Integer
        'write your implementation below
        'syntax is: UPDATE table_name SET column1=value1,column2=value2,...WHERE some_column=some_value;
        'example: UPDATE Customers SET ContactName='Alfred Schmidt', City='Hamburg' WHERE CustomerName='Alfreds Futterkiste'; 

        Return 0

    End Function

    Public Shared Function deleteDowStock(ByVal strTicker As String) As Integer
        'write your implementation below
        'syntax is: DELETE FROM table_name WHERE some_column=some_value; 
        'example: DELETE FROM Customers WHERE CustomerName='Alfreds Futterkiste'

        Return 0

    End Function

    Public Shared Function insertDowStock(ByRef stock As clsDowStock) As Integer
        'write your implementation below
        'syntax is:INSERT INTO table_name (column1,column2,column3,...) VALUES (value1,value2,value3,...);
        'example: INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country) 
        '         VALUES ('Cardinal','Tom B. Erichsen','Skagen 21','Stavanger','4006','Norway');

        Return 0

    End Function

    Public Shared Function getDowStock(ByVal strTicker As String) As clsDowStock
        Dim connection As SqlConnection = clsConnection.getConnection
        Dim strSelectStatement As String = "SELECT StockName, DivShare, Ticker " _
                                            & " FROM [DowIndustrialsSQL].[dbo].[tblDowStocks] WHERE Ticker ='" & strTicker & "'"
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
                                       "Please check your records and type a valid stock ticker")
        End If
        connection.Close()
        Return myDowStock
    End Function

    Public Shared Function updateStock(ByRef stock As clsDowStock) As Integer
        'write your implementation below
        'syntax is: UPDATE table_name SET column1=value1,column2=value2,...WHERE some_column=some_value;
        'example: UPDATE Customers SET ContactName='Alfred Schmidt', City='Hamburg' WHERE CustomerName='Alfreds Futterkiste'; 

        Try
            Dim connection As SqlConnection = clsConnection.getConnection
            Dim strUpdateStatement As String = "UPDATE  [DowIndustrialsSQL].[dbo].[tblDowStocks] " _
                                               & "SET StockName=' " & stock.StockName & "'" _
                                               & "WHERE Ticker ='" & stock.Ticker & "'"
            Dim command As New SqlCommand(strUpdateStatement, connection)
            connection.Open()

            Return command.ExecuteNonQuery()

        Catch ex As Exception
            'Generic exception
            Throw ex
        End Try
    End Function
End Class
