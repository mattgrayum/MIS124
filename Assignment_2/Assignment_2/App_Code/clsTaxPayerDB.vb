Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class clsTaxPayerDB
    Public Shared Function getTaxPayer(ByVal ID As Integer) As clsTaxPayer

        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblTaxPayer WHERE TaxPayerID =" & ID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)
        Dim taxPayer As clsTaxPayer = Nothing
        If dbReader.Read() Then
            taxPayer = New clsTaxPayer(dbReader.GetInt64(0), dbReader.GetString(1), dbReader.GetString(2),
                                       dbReader.GetString(3), dbReader.GetString(4), dbReader.GetString(5),
                                       dbReader.GetString(6), dbReader.GetString(7))
        Else
            Throw New ArgumentException("ERROR: SQL103. The Tax Payer ID that you entered does not exist in the database." & vbCrLf & vbCrLf &
                                       "Please check your records and enter a valid Tax Payer ID")
        End If
        connection.Close()
        Return taxPayer
    End Function

    Public Shared Function getTaxReturn(ByVal ID As Integer, ByVal Year As String) As clsTaxReturn
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblTaxReturn WHERE TaxPayerID = " & ID & " AND TaxYear = " & Year & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)
        Dim taxReturn As clsTaxReturn = Nothing
        If dbReader.Read() Then
            taxReturn = New clsTaxReturn(dbReader.GetInt64(0), dbReader.GetString(1), dbReader.GetBoolean(2),
                                         dbReader.GetDecimal(3), dbReader.GetDecimal(4), dbReader.GetDecimal(5),
                                         dbReader.GetString(6), dbReader.GetDecimal(7), dbReader.GetDecimal(8), dbReader.GetDecimal(9))
        Else
            taxReturn = Nothing
        End If
        connection.Close()
        Return taxReturn
    End Function

    Public Shared Function updateTaxReturn(ByRef taxReturn As clsTaxReturn) As Integer

        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "UPDATE dbo.tblTaxReturn SET [IsJointTaxReturn]='" & taxReturn.IsJointReturn &
                                "', [Wages] =" & taxReturn.Wages & ", [TaxableInterest] = " & taxReturn.TaxableInterest &
                                ", [UnemploymentCompensation]=" & taxReturn.UnemploymentCompensation &
                                ", [DependentStatus]='" & taxReturn.DependentStatus & "', [IncomeTaxWithheld]=" & taxReturn.IncomeTaxWithheld &
                                ", [EarnedIncomeCredit]=" & taxReturn.EIC & ", [NontaxableCompatPay]=" & taxReturn.CompatPay &
                                " WHERE TaxPayerID = " & taxReturn.TaxPayerID & " AND TaxYear = " & taxReturn.Year & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim result As Integer = dbCommand.ExecuteNonQuery()
        connection.Close()

        Return result
    End Function

    Public Shared Function insertTaxReturn(ByRef taxReturn As clsTaxReturn) As Integer
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "INSERT INTO dbo.tblTaxReturn (TaxPayerID, TaxYear, IsJointTaxReturn, Wages, TaxableInterest, UnemploymentCompensation" &
                               ", DependentStatus, IncomeTaxWithheld, EarnedIncomeCredit, NontaxableCompatPay) VALUES (" & taxReturn.TaxPayerID &
                               ", " & taxReturn.Year & ", '" & taxReturn.IsJointReturn & "', " & taxReturn.Wages & ", " & taxReturn.TaxableInterest &
                               ", " & taxReturn.UnemploymentCompensation & ", '" & taxReturn.DependentStatus & "', " & taxReturn.IncomeTaxWithheld &
                               ", " & taxReturn.EIC & ", " & taxReturn.CompatPay & ");"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim result As Integer = dbCommand.ExecuteNonQuery()
        connection.Close()

        Return result
    End Function

    Public Shared Function updateJointTaxPayer(ByVal jointTaxPayer As JointTaxPayer) As Integer
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "UPDATE dbo.tblJointTaxPayer SET [JointLastName]='" & jointTaxPayer.lastName &
                               "', [JointFirstName]='" & jointTaxPayer.firstName & "', [JointInitial]='" & jointTaxPayer.middleInitial &
                               "' WHERE [TaxPayerID]=" & jointTaxPayer.taxPayerID & ";"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim result As Integer = dbCommand.ExecuteNonQuery()
        connection.Close()

        Return result
    End Function

    Public Shared Function insertJointTaxPayer(ByVal jointTaxPayer As JointTaxPayer) As Integer
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "INSERT INTO dbo.tblJointTaxPayer VALUES ('" & jointTaxPayer.lastName & "', '" & jointTaxPayer.firstName &
                               "', '" & jointTaxPayer.middleInitial & "', " & jointTaxPayer.taxPayerID & ");"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim result As Integer = dbCommand.ExecuteNonQuery()
        connection.Close()

        Return result
    End Function
End Class
