
Partial Class _Default
    Inherits Page

    Protected Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect(url:="Default.aspx")
    End Sub
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load
        Dim trsx As clsTaxRates = New clsTaxRates("localhost")
    End Sub
End Class