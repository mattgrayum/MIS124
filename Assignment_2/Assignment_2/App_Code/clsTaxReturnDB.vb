Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clsTaxReturnDB


    '*******************************************************************************************************************
    ' Function isTaxReturn
    '   This function checks the database to see if a tax return exists for the given tax payer and year.
    '   SqlCommand.ExecuteScalar returns the value of the first column of the first row from the query, 
    '   or Nothing if the record doesn't exist in the database. 
    ' Returns:
    '   isReturn as Boolean
    ' Parameters:
    '   ID as Integer - The tax payer ID
    '   year as String - The year of the tax return
    '*******************************************************************************************************************
    Public Shared Function isTaxReturn(ByVal ID As Integer, ByVal year As String) As Boolean

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblTaxReturn WHERE TaxPayerID = " & ID & " AND TaxYear = " & year & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Check if a tax return exists in the database
        Dim isReturn As Boolean = True
        If dbCommand.ExecuteScalar = Nothing Then
            isReturn = False
        End If

        'Close the database connection
        connection.Close()

        Return isReturn

    End Function

    '*******************************************************************************************************************
    ' Function getTaxReturn
    '   This function queries the database for a tax payer record that with the passed ID
    ' Returns:
    '   taxPayer as clsTaxPayer
    ' Parameters:
    '   ID as Integer - The tax payer ID
    '*******************************************************************************************************************
    Public Shared Function getTaxReturn(ByVal ID As Integer, ByVal Year As String) As clsTaxReturn

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblTaxReturn WHERE TaxPayerID = " & ID & " AND TaxYear = '" & Year & "';"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Set up a reader object to read a single row from the database
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)

        'Read a tax return record from the database and populate a clsTaxReturn object with the data
        Dim taxReturn As clsTaxReturn = Nothing
        If dbReader.Read() Then
            taxReturn = New clsTaxReturn(dbReader.GetInt64(0), dbReader.GetString(1), dbReader.GetBoolean(2),
                                         dbReader.GetDecimal(3), dbReader.GetDecimal(4), dbReader.GetDecimal(5),
                                         dbReader.GetString(6), dbReader.GetDecimal(7), dbReader.GetDecimal(8), dbReader.GetDecimal(9))
        Else
            'If no tax return is found, return a clsTaxReturn object with zeroed out values
            taxReturn = New clsTaxReturn(ID, Year, False, 0, 0, 0, {"0", "0"}, 0, 0, 0)
        End If

        'Close the database connection
        connection.Close()

        Return taxReturn

    End Function

    '*******************************************************************************************************************
    ' Function updateTaxReturn
    '   This function updates the Tax Return table with new data from a web form
    ' Returns:
    '   result as Integer - The number of rows affected by the operation.
    ' Parameters:
    '   taxReturn as clsTaxReturn
    '*******************************************************************************************************************
    Public Shared Function updateTaxReturn(ByRef taxReturn As clsTaxReturn) As Integer

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "UPDATE dbo.tblTaxReturn SET [IsJointTaxReturn]='" & taxReturn.IsJointReturn &
                                "', [Wages] =" & taxReturn.Wages & ", [TaxableInterest] = " & taxReturn.TaxableInterest &
                                ", [UnemploymentCompensation]=" & taxReturn.UnemploymentCompensation &
                                ", [DependentStatus]='" & taxReturn.DependentStatus & "', [IncomeTaxWithheld]=" & taxReturn.IncomeTaxWithheld &
                                ", [EarnedIncomeCredit]=" & taxReturn.EIC & ", [NontaxableCompatPay]=" & taxReturn.CompatPay &
                                " WHERE TaxPayerID = " & taxReturn.TaxPayerID & " AND TaxYear = '" & taxReturn.Year & "';"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Execute the update
        Dim result As Integer = dbCommand.ExecuteNonQuery()

        'Close the database connection
        connection.Close()

        Return result

    End Function

    '*******************************************************************************************************************
    ' Function insertTaxReturn
    '   This function adds a new Tax Return to the database.
    ' Returns:
    '   result as Integer - The number of rows affected by the operation.
    ' Parameters:
    '   taxRetur as clsTaxReturn
    '*******************************************************************************************************************
    Public Shared Function insertTaxReturn(ByRef taxReturn As clsTaxReturn) As Integer

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "INSERT INTO dbo.tblTaxReturn (TaxPayerID, TaxYear, IsJointTaxReturn, Wages, TaxableInterest, UnemploymentCompensation" &
                               ", DependentStatus, IncomeTaxWithheld, EarnedIncomeCredit, NontaxableCompatPay) VALUES (" & taxReturn.TaxPayerID &
                               ", " & taxReturn.Year & ", '" & taxReturn.IsJointReturn & "', " & taxReturn.Wages & ", " & taxReturn.TaxableInterest &
                               ", " & taxReturn.UnemploymentCompensation & ", '" & taxReturn.DependentStatus & "', " & taxReturn.IncomeTaxWithheld &
                               ", " & taxReturn.EIC & ", " & taxReturn.CompatPay & ");"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Execute the insert
        Dim result As Integer = dbCommand.ExecuteNonQuery()

        'Close the database connection
        connection.Close()

        Return result

    End Function

End Class
