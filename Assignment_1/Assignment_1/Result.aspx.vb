
Partial Class _Default
    Inherits Page

    Protected Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        Response.Redirect(url:="~/Default.aspx", endResponse:=False)

    End Sub
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        Dim strIndividualOrJoint As String = Session("individualOrJoint")
        Dim dblWages As Double = Session("wages")
        Dim dblTaxableInterest As Double = Session("interest")
        Dim dblUnemploymentCompensation As Double = Session("unemployment")
        Dim dblIncomeTaxWithheld As Double = Session("withholding")
        Dim dblEIC As Double = Session("eic")
        Dim dblCompatPay As Double = Session("nontaxable")
        Dim intNumberOfTaxpayers As Integer = Session("numberOfTaxpayers")
        Dim boolYouChecked As Boolean = Session("you")
        Dim boolSpouseChecked As Boolean = Session("spouse")

        Dim intNumberOfDependentTaxpayers As Integer = 0
        If (boolYouChecked) Then
            intNumberOfDependentTaxpayers += 1
        End If
        If (boolSpouseChecked) Then
            intNumberOfDependentTaxpayers += 1
        End If

        Dim strServerPath As String = "C:\Users\Matthew Grayum\source\repos\MIS124\Assignment_1\Assignment_1\"
        Dim taxReturn As clsTaxReturn = New clsTaxReturn(dblWages, dblTaxableInterest, dblUnemploymentCompensation, dblIncomeTaxWithheld, dblEIC, dblCompatPay, intNumberOfTaxpayers, intNumberOfDependentTaxpayers, strServerPath)
        Dim dblFinalTax As Double = taxReturn.calculateTaxReturn()

        lblIndividualOrJointResult.Text = strIndividualOrJoint
        txtWagesResult.Text = FormatCurrency(dblWages, 2)
        txtInterestResult.Text = FormatCurrency(dblTaxableInterest, 2)
        txtUnemploymentResult.Text = FormatCurrency(dblUnemploymentCompensation, 2)

        lblGrossIncomeResult.Text = FormatCurrency(taxReturn.AdjustedGrossIncome(), 2)
        lblNumDependents.Text = intNumberOfDependentTaxpayers.ToString
        lblDependentResult.Text = FormatCurrency(taxReturn.ExcemptionAmount(), 2)
        lblTaxableIncome.Text = FormatCurrency(taxReturn.TaxableIncome(), 2)
        txtWithholdingResult.Text = FormatCurrency(dblIncomeTaxWithheld, 2)
        txtEarnedIncomeResult.Text = FormatCurrency(dblEIC, 2)
        txtNontaxableResult.Text = FormatCurrency(dblCompatPay, 2)
        lblTotalPaymentsResult.Text = FormatCurrency(taxReturn.TotalPayments(), 2)
        lblCalculatedTaxResult.Text = FormatCurrency(taxReturn.Tax(), 2)

        If dblFinalTax > 0 Then
            lblRefundMsg.Text = "14. This is the amount of your refund."
            lblTaxRefund.Text = FormatCurrency(dblFinalTax, 2)
        Else
            lblTaxOwedMsg.Text = "14. This is the amount you owe."
            lblTaxOwed.Text = FormatCurrency(dblFinalTax, 2)
        End If

    End Sub
End Class