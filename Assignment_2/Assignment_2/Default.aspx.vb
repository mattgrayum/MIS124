
Partial Class _Default
    Inherits Page

    Protected Sub btnViewTaxReturn_Click(sender As Object, e As EventArgs) Handles btnViewTaxReturn.Click

        'TODO: Replace hardcoded values with control values from Default.aspx
        Session("taxPayer") = clsTaxPayerDB.getTaxPayer(lstTaxPayers.SelectedValue)
        Session("taxReturn") = clsTaxPayerDB.getTaxReturn(lstTaxPayers.SelectedValue, txtTaxYear.Text)
        ' Redirect to the DisplayTaxReturn Page
        Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class