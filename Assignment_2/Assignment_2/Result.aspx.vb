
Partial Class Result
    Inherits System.Web.UI.Page

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************

    ' -- Calculates tax information from data entered on previous page
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        If Not IsPostBack Then

            Try

                'Populate tax payer form controls 
                Dim taxPayer As clsTaxPayer = Session("taxPayer")
                lblTaxPayerID.Text = taxPayer.TaxPayerID.ToString
                lblTaxYear.Text = Session("taxYear")
                txtFirstName.Text = taxPayer.FirstName
                txtLastName.Text = taxPayer.LastName
                txtState.Text = taxPayer.State
                txtCity.Text = taxPayer.City
                txtMI.Text = taxPayer.MidInitial
                txtZipCode.Text = taxPayer.Zip

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

                'Set up intnumberOfDependentTaxpayers with the correct value
                Dim intnumberOfDependentTaxpayers As Integer = 0
                If taxReturn.DependentStatus(0) = "1" Then
                    intnumberOfDependentTaxpayers += 1
                End If
                If taxReturn.DependentStatus(1) = "1" Then
                    intnumberOfDependentTaxpayers += 1
                End If

                'Populate the calculated tax return form controls
                txtWagesResult.Text = FormatCurrency(taxReturn.Wages, 2)
                txtInterestResult.Text = FormatCurrency(taxReturn.TaxableInterest, 2)
                txtUnemploymentResult.Text = FormatCurrency(taxReturn.UnemploymentCompensation, 2)
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

                'Provide a success message
                Utlilties.showSuccessMessage(lblMessage, pnlMessage, "Here are your calculated tax return results.")

                'Pie Chart


                Dim myPieChartValue1 As New AjaxControlToolkit.PieChartValue
                myPieChartValue1.Category = "Adjusted Gross Income"
                myPieChartValue1.PieChartValueColor = RGB(0, 0, 0)
                myPieChartValue1.Data = taxReturn.AdjustedGrossIncome()

                Dim myPieChartValue2 As New AjaxControlToolkit.PieChartValue
                myPieChartValue2.Category = "Taxes"
                myPieChartValue2.PieChartValueColor = RGB(100, 100, 100)
                myPieChartValue2.Data = taxReturn.Tax()

                Dim pieChart As New AjaxControlToolkit.PieChart
                pieChart = myPieChart

                pieChart.PieChartValues.Add(myPieChartValue1)
                pieChart.PieChartValues.Add(myPieChartValue2)


                lblAdjustedGrossIncomeRatio.Text = FormatPercent(taxReturn.Tax / taxReturn.AdjustedGrossIncome, 2)
                lblTaxesWagesRatio.Text = FormatPercent(taxReturn.Tax / taxReturn.Wages, 2)
                lblWithheldOwedRatio.Text = FormatPercent(taxReturn.IncomeTaxWithheld / dblFinalTax, 2)


            Catch ex As Exception
                Utlilties.showErrorMessage(lblMessage, pnlMessage, ex)
            End Try

        End If

    End Sub

    'Sends out an e-mail message
    Private Sub emailTaxResults()
        Try
            Dim myMailServer As String = "smtp.saclink.csus.edu"
            Dim taxReturn As clsTaxReturn
            If Not Session("taxReturn") Is Nothing Then
                taxReturn = Session("taxReturn")
                Dim decFinalTax As Decimal = taxReturn.calculateTaxReturn()
                Dim finalTaxMessage As String = "This is the amount you owe:_____________"
                If decFinalTax > 0 Then
                    finalTaxMessage = "This is the amount of your tax return:__"
                End If
                Dim emailBody As String = "Wages, salaries, and tips:______________" & FormatCurrency(taxReturn.Wages, 2).PadLeft(12) & vbCrLf &
                                          "Taxable interest:_______________________" & FormatCurrency(taxReturn.TaxableInterest, 2).PadLeft(12) & vbCrLf &
                                          "Unemployment compensation:______________" & FormatCurrency(taxReturn.UnemploymentCompensation, 2).PadLeft(12) & vbCrLf &
                                          "Adjusted gross income:__________________" & FormatCurrency(taxReturn.AdjustedGrossIncome, 2).PadLeft(12) & vbCrLf &
                                          "Number of dependent tax payers:_________" & taxReturn.NumberOfDependentTaxpayers.ToString.PadLeft(12) & vbCrLf &
                                          "Taxable income:_________________________" & FormatCurrency(taxReturn.TaxableIncome, 2).PadLeft(12) & vbCrLf &
                                          "Withholding:____________________________" & FormatCurrency(taxReturn.IncomeTaxWithheld, 2).PadLeft(12) & vbCrLf &
                                          "Earned Income Credit:___________________" & FormatCurrency(taxReturn.EIC, 2).PadLeft(12) & vbCrLf &
                                          "Nontaxable combat pay:__________________" & FormatCurrency(taxReturn.CompatPay, 2).PadLeft(12) & vbCrLf &
                                          "Total payments:_________________________" & FormatCurrency(taxReturn.TotalPayments, 2).PadLeft(12) & vbCrLf &
                                          "Your tax:_______________________________" & FormatCurrency(taxReturn.Tax, 2).PadLeft(12) & vbCrLf &
                                          finalTaxMessage.PadRight(40) & FormatCurrency(taxReturn.calculateTaxReturn(), 2).PadLeft(12)


                Dim objMyMailMessage As New System.Net.Mail.MailMessage("mattgrayum@gmail.com", txtEmail.Text, "Tax Return Information", emailBody)
                Dim objMyWebServer As New System.Net.Mail.SmtpClient(myMailServer)
                objMyWebServer.Send(objMyMailMessage)
                lblMessage.Text = "Mail was sent"
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message()
        End Try
    End Sub

    '*******************************************************************************************************************
    'ACTION ON OK BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        lblMessage.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        emailTaxResults()
        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert('Your tax return information has been emailed to you')</SCRIPT>")

    End Sub

    '*******************************************************************************************************************
    'ACTION ON BACK BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        ' Redirect back to the DisplayTaxReturn Page
        Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)

    End Sub

End Class
