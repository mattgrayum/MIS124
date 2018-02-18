
Partial Class _Default
    Inherits Page

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect(url:="Default.aspx")
    End Sub
End Class