Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class clsTaxPayerDB
    Public Shared Function getTaxPayer(ByVal ID As Integer) As clsTaxPayer

        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblTaxPayer WHERE TaxPayerID = 1;"
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

        Return taxPayer
    End Function

    Public Shared Function getTaxReturn(ByVal ID As Integer, ByVal Year As String) As clsTaxReturn
        Dim connection As SqlConnection = clsDBConnection.getConnection()
        Dim strSQL As String = "SELECT * FROM dbo.tblTaxReturn WHERE TaxPayerID = 1 AND TaxYear = 2014;"
        Dim dbCommand As New SqlCommand(strSQL, connection)
        connection.Open()
        Dim dbReader As SqlDataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow)
        Dim taxReturn As clsTaxReturn = Nothing
        If dbReader.Read() Then
            taxReturn = New clsTaxReturn(dbReader.GetInt64(0), dbReader.GetString(1), dbReader.GetBoolean(2),
                                         dbReader.GetDecimal(3), dbReader.GetDecimal(4), dbReader.GetDecimal(5),
                                         dbReader.GetString(6), dbReader.GetDecimal(7), dbReader.GetDecimal(8), dbReader.GetDecimal(9))
        Else
            Throw New ArgumentException("ERROR: SQL103. The Tax Payer ID that you entered does not exist in the database." & vbCrLf & vbCrLf &
                                       "Please check your records and enter a valid Tax Payer ID")
        End If

        Return taxReturn
    End Function


End Class
