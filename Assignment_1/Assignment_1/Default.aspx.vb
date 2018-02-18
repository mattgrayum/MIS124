
Partial Class _Default
    Inherits Page

    Protected Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Server.Transfer("Result.aspx")
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
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load
        Session("wages") = txtWages.Text
        Session("interest") = txtInterest.Text
        Session("unemployment") = txtUnemployment.Text
        Session("withholding") = txtWithholding.Text
        Session("nontaxable") = txtNontaxable.Text
        Session("you") = chkYou.Checked
        Session("spouse") = chkSpouse.Checked

    End Sub
End Class