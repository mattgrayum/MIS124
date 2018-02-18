
Partial Class _Default
    Inherits Page

    Protected Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Response.Redirect(url:="Result.aspx")
    End Sub
End Class