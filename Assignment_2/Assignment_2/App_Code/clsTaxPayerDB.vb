Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class clsTaxPayerDB

    '*******************************************************************************************************************
    ' Function getTaxPayer
    '   This function queries the database for a tax payer record that with the passed ID
    ' Returns:
    '   taxPayer as clsTaxPayer
    ' Parameters:
    '   ID as Integer - The tax payer ID
    '*******************************************************************************************************************
    Public Shared Function getTaxPayer(ByVal ID As Integer) As clsTaxPayer

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblTaxPayer WHERE TaxPayerID =" & ID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Set up a reader object to read a single row from the database
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)

        'Read in the data and populate a new clsTaxPayer object if a record was found
        Dim taxPayer As clsTaxPayer = Nothing
        If dbReader.Read() Then
            taxPayer = New clsTaxPayer(dbReader.GetInt64(0), dbReader.GetString(1), dbReader.GetString(2),
                                       dbReader.GetString(3), dbReader.GetString(4), dbReader.GetString(5),
                                       dbReader.GetString(6), dbReader.GetString(7))
        Else
            Throw New ArgumentException("ERROR: SQL103. The Tax Payer ID that you entered does not exist in the database." & vbCrLf & vbCrLf &
                                       "Please check your records and enter a valid Tax Payer ID")
        End If

        'Close the database connection
        connection.Close()

        Return taxPayer

    End Function

    '*******************************************************************************************************************
    ' Function updateTaxPayer
    '   This function updates the TaxPayer table with new data from a web form
    ' Returns:
    '   result as Integer - The number of rows affected by the operation.
    ' Parameters:
    '   taxPayer as clsTaxPayer
    '*******************************************************************************************************************
    Public Shared Function updateTaxPayer(ByRef taxPayer As clsTaxPayer) As Integer

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "UPDATE dbo.tblTaxPayer SET [TaxPayerLastName]='" & taxPayer.LastName & "', [TaxPayerFirstName]='" & taxPayer.FirstName &
                                "', [TaxPayerInitial]='" & taxPayer.MidInitial & "', [TaxPayerAddress]='" & taxPayer.Address & "', [TaxPayerCity]='" & taxPayer.City &
                                "', [TaxPayerState]='" & taxPayer.State & "', [TaxPayerZip]='" & taxPayer.Zip & "' WHERE [TaxPayerID] = " & taxPayer.TaxPayerID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Execute the update
        Dim result As Integer = dbCommand.ExecuteNonQuery()

        'Close the database connection
        connection.Close()

        Return result

    End Function

    '*******************************************************************************************************************
    ' Function updateJointTaxPayer
    '   This function updates the Joint Tax Payer table with new data from web form
    ' Returns:
    '   result as Integer - The number of rows affected by the operation.
    ' Parameters:
    '   jointTaxPayer as JointTaxPayer
    '*******************************************************************************************************************
    Public Shared Function updateJointTaxPayer(ByVal jointTaxPayer As structJointTaxPayer) As Integer

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "UPDATE dbo.tblJointTaxPayer SET [JointLastName]='" & jointTaxPayer.lastName &
                               "', [JointFirstName]='" & jointTaxPayer.firstName & "', [JointInitial]='" & jointTaxPayer.middleInitial &
                               "' WHERE [TaxPayerID]=" & jointTaxPayer.taxPayerID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Execute the update
        Dim result As Integer = dbCommand.ExecuteNonQuery()

        'Close the database connection
        connection.Close()

        Return result

    End Function

    '*******************************************************************************************************************
    ' Function insertJointTaxPayer
    '   This function adds a new Joint Tax Payer to the database
    ' Returns:
    '   result as Integer - The number of rows affected by the operation.
    ' Parameters:
    '   jointTaxPayer as JointTaxPayer
    '*******************************************************************************************************************
    Public Shared Function insertJointTaxPayer(ByVal jointTaxPayer As structJointTaxPayer) As Integer

        'Set up a database connection, define the SELECT statement, set up a command object, and open the db connection
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "INSERT INTO dbo.tblJointTaxPayer VALUES ('" & jointTaxPayer.lastName & "', '" & jointTaxPayer.firstName &
                               "', '" & jointTaxPayer.middleInitial & "', " & jointTaxPayer.taxPayerID & ");"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()

        'Execute the insert
        Dim result As Integer = dbCommand.ExecuteNonQuery()

        'Close the database connection
        connection.Close()

        Return result

    End Function

End Class
