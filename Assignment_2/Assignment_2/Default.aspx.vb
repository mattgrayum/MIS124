
Partial Class _Default
    Inherits Page

    Protected Sub btnViewTaxReturn_Click(sender As Object, e As EventArgs) Handles btnViewTaxReturn.Click

        Session("taxPayer") = clsTaxPayerDB.getTaxPayer(lstTaxPayers.SelectedValue)

        Dim taxReturn As clsTaxReturn = clsTaxPayerDB.getTaxReturn(lstTaxPayers.SelectedValue, txtTaxYear.Text)
        If taxReturn Is Nothing Then
            MsgBox("A tax return does not exist for this tax payer and this year." & vbCrLf &
                   "Please enter the tax return information in the spaces provided on the next page and click 'Insert'.")
        Else
            Session("taxReturn") = taxReturn
        End If
        Session("taxYear") = txtTaxYear.Text
        ' Redirect to the DisplayTaxReturn Page
        Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)



    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class