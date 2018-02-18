'***********************************************************************************************************************
'Class Name:        clsTaxRates.vb
'Version:           1.00
'Programmer/s:      Spiros Velianitis
'Date:              Jan 6, 2017
'Purpose:           Calculates the tax for all taxpayers using the tax tables
'***********************************************************************************************************************

Public Class clsTaxRates

    Private lstTaxTable As List(Of TaxTableStructure)
    Public Sub New(serverpath As String)

        lstTaxTable = New List(Of TaxTableStructure)
        Dim index As Integer = 0
        Using myReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(serverpath & "\App_Data\TaxTable2017.csv")
            myReader.ReadLine()   '  Ignore first record
            While Not myReader.EndOfData
                Dim myTaxTableRecord As New TaxTableStructure

                Dim strLineRead As String = myReader.ReadLine()
                Dim strLineItems() As String = strLineRead.Split(",")

                myTaxTableRecord.AtLeast = CInt(strLineItems(0))
                myTaxTableRecord.ButLessThan = CInt(strLineItems(1))
                myTaxTableRecord.SingleTax = CInt(strLineItems(2))
                myTaxTableRecord.MarriedFilingJointlyTax = CInt(strLineItems(3))
                myTaxTableRecord.MarriedFilingSeparatelyTax = CInt(strLineItems(4))
                myTaxTableRecord.HeadOfHouseholdTax = CInt(strLineItems(5))

                lstTaxTable.Add(myTaxTableRecord)
            End While
        End Using
    End Sub


    Public Function findTaxRow(ByVal dblTaxableIncome As Double) As TaxTableStructure
        Dim index As Integer
        For index = lstTaxTable.Count - 1 To 0 Step -1
            If dblTaxableIncome >= lstTaxTable(index).AtLeast Then
                Return lstTaxTable(index)
            End If
        Next
    End Function

End Class
