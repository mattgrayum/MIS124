
Partial Class DisplayTaxReturn
    Inherits System.Web.UI.Page

    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' Redirect to the Result Page
        Response.Redirect(url:="~/Result.aspx", endResponse:=False)
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Redirect back to the Default Page
        Response.Redirect(url:="~/Default.aspx", endResponse:=False)
    End Sub
End Class
