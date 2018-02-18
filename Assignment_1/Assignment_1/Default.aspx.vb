
Partial Class _Default
    Inherits Page

    Protected Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Response.Redirect(url:="Result.aspx")
    End Sub
    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtWages.Text = ""
        txtInterest.Text = ""
        txtUnemployment.Text = ""
        chkYou.Checked = False
        chkSpouse.Checked = False
        txtWithholding.Text = ""
        txtNontaxable.Text = ""
    End Sub

End Class