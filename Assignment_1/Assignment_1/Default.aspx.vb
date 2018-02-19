
Partial Class _Default
    Inherits Page

    Protected Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        Response.Redirect("Result.aspx", False)

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

        If Not IsPostBack Then

            If lstIndividualOrJoint.SelectedIndex = 0 Then
                Session("numberOfTaxpayers") = 1
                Session("individualOrJoint") = "Individual"
            Else
                Session("numberOfTaxpayers") = 2
                Session("individualOrJoint") = "Joint"
            End If

            Session("wages") = txtWages.Text
            Session("interest") = txtInterest.Text
            Session("unemployment") = txtUnemployment.Text
            Session("you") = chkYou.Checked
            Session("spouse") = chkSpouse.Checked
            Session("withholding") = txtWithholding.Text
            Session("eic") = txtEarnedIncome.Text
            Session("nontaxable") = txtNontaxable.Text

        Else

            lstIndividualOrJoint.SelectedIndex = CType(Session.Item("numberOfTaxpayers"), Integer) - 1
            txtWages.Text = CType(Session.Item("wages"), String)
            txtInterest.Text = CType(Session.Item("interest"), String)
            txtUnemployment.Text = CType(Session.Item("unemployment"), String)
            chkYou.Checked = CType(Session.Item("you"), Boolean)
            chkSpouse.Checked = CType(Session.Item("spouse"), Boolean)
            txtWithholding.Text = CType(Session.Item("withholding"), String)
            txtEarnedIncome.Text = CType(Session.Item("eic"), String)
            txtNontaxable.Text = CType(Session.Item("nontaxable"), String)

        End If


    End Sub
End Class