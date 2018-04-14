
Partial Class Result
    Inherits System.Web.UI.Page

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Redirect back to the DisplayTaxReturn Page
        Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)
    End Sub

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************

    ' -- Calculates tax information from data entered on previous page
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        ' Instantiate a clsTaxReturn object
        Dim taxReturn As clsTaxReturn = Session("taxReturn")
        taxReturn.ServerPath = Server.MapPath(path:=".")
        ' Call the calculateTaxReturn() method of the clsTaxReturn class and assign the returned value to a variable
        Dim dblFinalTax As Double = taxReturn.calculateTaxReturn()

        ' Populate the form fields with a combination of the data passed by the user and the values
        ' calculated by the calculateTaxReturn() method above.
        lblIndividualOrJointResult.Text = "Individual"
        If taxReturn.IsJointReturn Then
            lblIndividualOrJointResult.Text = "Joint"
        End If

        txtWagesResult.Text = FormatCurrency(taxReturn.Wages, 2)
        txtInterestResult.Text = FormatCurrency(taxReturn.TaxableInterest, 2)
        txtUnemploymentResult.Text = FormatCurrency(taxReturn.UnemploymentCompensation, 2)

        Dim intnumberOfDependentTaxpayers As Integer = 0
        If taxReturn.DependentStatus(0) = "1" Then
            intnumberOfDependentTaxpayers += 1
        End If
        If taxReturn.DependentStatus(1) = "1" Then
            intnumberOfDependentTaxpayers += 1
        End If
        lblNumDependents.Text = intnumberOfDependentTaxpayers.ToString

        txtWithholdingResult.Text = FormatCurrency(taxReturn.IncomeTaxWithheld, 2)
        txtEarnedIncomeResult.Text = FormatCurrency(taxReturn.EIC, 2)
        txtNontaxableResult.Text = FormatCurrency(taxReturn.CompatPay, 2)



        lblGrossIncomeResult.Text = FormatCurrency(taxReturn.AdjustedGrossIncome(), 2)

        lblDependentResult.Text = FormatCurrency(taxReturn.ExcemptionAmount(), 2)
        lblTaxableIncome.Text = FormatCurrency(taxReturn.TaxableIncome(), 2)

        lblTotalPaymentsResult.Text = FormatCurrency(taxReturn.TotalPayments(), 2)
        lblCalculatedTaxResult.Text = FormatCurrency(taxReturn.Tax(), 2)

        ' Conditionaly display the final message and amount depending on whether taxes are owed or a refund is due
        If dblFinalTax > 0 Then
            lblRefundMsg.Text = "14. This is the amount of your refund."
            lblTaxRefund.Text = FormatCurrency(dblFinalTax, 2)
        Else
            lblTaxOwedMsg.Text = "14. This is the amount you owe."
            lblTaxOwed.Text = FormatCurrency(dblFinalTax, 2)
        End If

    End Sub
End Class
