
Partial Class _Default
    Inherits Page

    Protected Sub btnViewTaxReturn_Click(sender As Object, e As EventArgs) Handles btnViewTaxReturn.Click
        ' Redirect to the DisplayTaxReturn Page
        Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)
    End Sub
End Class