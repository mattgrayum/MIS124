
Partial Class _Default
    Inherits Page

    Protected Sub btnViewTaxReturn_Click(sender As Object, e As EventArgs) Handles btnViewTaxReturn.Click

        'TODO: Replace hardcoded values with control values from Default.aspx
        Session("taxPayer") = clsTaxPayerDB.getTaxPayer(2)
        Session("taxReturn") = clsTaxPayerDB.getTaxReturn(2, "2014")
        ' Redirect to the DisplayTaxReturn Page
        Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class