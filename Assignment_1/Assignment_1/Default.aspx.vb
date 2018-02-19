
Partial Class _Default
    Inherits Page

    '*******************************************************************************************************************
    'ACTION ON "CALCULATE" BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        ' Populate session variables with user-enetered values 
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

        ' Redirect to Results Page
        Response.Redirect(url:="~/Result.aspx", endResponse:=False)

    End Sub
    '*******************************************************************************************************************
    'ACTION ON "CLEAR" BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ' Set each input field to nothing
        txtWages.Text = ""
        txtInterest.Text = ""
        txtUnemployment.Text = ""
        chkYou.Checked = False
        chkSpouse.Checked = False
        txtEarnedIncome = ""
        txtWithholding.Text = ""
        txtNontaxable.Text = ""

    End Sub
    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        ' Set each input field to the value of the associated Session variable
        If Session("numberOfTaxpayers") IsNot Nothing Then
            lstIndividualOrJoint.SelectedIndex = Session("numberOfTaxpayers") - 1
        End If
        If Session("wages") IsNot Nothing Then
            txtWages.Text = Session("wages")
        End If
        If Session("interest") IsNot Nothing Then
            txtInterest.Text = Session("interest")
        End If
        If Session("unemployment") IsNot Nothing Then
            txtUnemployment.Text = Session("unemployment")
        End If
        If Session("you") IsNot Nothing Then
            chkYou.Checked = Session("you")
        End If
        If Session("spouse") IsNot Nothing Then
            chkSpouse.Checked = Session("spouse")
        End If
        If Session("withholding") IsNot Nothing Then
            txtWithholding.Text = Session("withholding")
        End If
        If Session("eic") IsNot Nothing Then
            txtEarnedIncome.Text = Session("eic")
        End If
        If Session("nontaxable") IsNot Nothing Then
            txtNontaxable.Text = Session("nontaxable")
        End If

    End Sub
End Class