﻿
Partial Class DisplayTaxReturn
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load
        Dim taxPayer As clsTaxPayer = Session("taxPayer")
        Dim taxReturn As clsTaxReturn = Session("taxReturn")

        lblTaxPayerID.Text = taxPayer.TaxPayerID.ToString
        txtFirstName.Text = taxPayer.FirstName
        txtLastName.Text = taxPayer.LastName
        txtState.Text = taxPayer.State
        txtCity.Text = taxPayer.City
        txtMI.Text = taxPayer.MidInitial
        txtZipCode.Text = taxPayer.Zip

        lstIndividualOrJoint.SelectedIndex = 0
        If taxReturn.IsJointReturn Then
            lstIndividualOrJoint.SelectedIndex = 1
        End If
        txtWages.Text = taxReturn.Wages
        txtInterest.Text = taxReturn.TaxableInterest
        txtUnemployment.Text = taxReturn.UnemploymentCompensation
        If taxReturn.DependentStatus.Chars(0).ToString = "1" Then
            chkYou.Checked = True
        End If
        If taxReturn.DependentStatus.Chars(1).ToString = "1" Then
            chkSpouse.Checked = True
        End If
        txtWithholding.Text = taxReturn.IncomeTaxWithheld
        txtEarnedIncome.Text = taxReturn.EIC
        txtNontaxable.Text = taxReturn.CompatPay
    End Sub
    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' Redirect to the Result Page
        Response.Redirect(url:="~/Result.aspx", endResponse:=False)
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Redirect back to the Default Page
        Response.Redirect(url:="~/Default.aspx", endResponse:=False)
    End Sub
End Class
