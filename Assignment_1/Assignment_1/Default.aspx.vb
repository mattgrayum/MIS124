
Partial Class _Default
    Inherits Page
    Private Const MAX_WAGES = 99999.99
    '*******************************************************************************************************************
    'ACTION ON "CALCULATE" BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        If CType(txtWages.Text, Double) > MAX_WAGES Then
            lblMessage.Text = "You can use Form 1040EZ only if your Taxable Income (line 6) is less than $100,000."
            pnlMessage.Attributes.Add("style", "border-style: solid; border-width: thin; margin-top: 10px; padding: 5px; text-align: center; color: white; background-color: red;")
            txtWages.Attributes.Add("style", "background-color: #fcbdbd")
            txtWages.Focus()
            Exit Sub
        End If

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
        Session("name") = txtName.Text

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
        txtEarnedIncome.Text = ""
        txtWithholding.Text = ""
        txtNontaxable.Text = ""

        ' Reset wages textbox and bottom message box in case user had entered invalid data and caused them to change
        lblMessage.Text = "Enter your tax information and click calculate to view your results"
        pnlMessage.Attributes.Add("style", "border-style: solid; border-width: thin; background-color: oldlace; margin-top: 10px; padding: 5px; text-align: center;")
        txtWages.Attributes.Add("style", "background-color: #fff")
        txtWages.Focus()

    End Sub
    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        ' Set each input field to the value of the associated Session variable
        If Not IsPostBack Then

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

            Dim myCookie As HttpCookie = Request.Cookies("UserName")

            If myCookie IsNot Nothing Then
                txtName.Attributes.Add("style", value:="display: none;")
                lblName.Text = "Welcome " & myCookie.Value
            End If

        End If

        ' Set focus to the wages textbox so user doesn't have to click into it
        txtWages.Focus()
    End Sub

    Protected Sub txtName_TextChanged(sender As Object, e As EventArgs)
        lblName.Text = "Welcome " & txtName.Text
        txtName.Attributes.Add("style", value:="display: none;")

        Try
            Dim myCookie As New HttpCookie("UserName", txtName.Text)
            myCookie.Expires = DateTime.MaxValue
            Response.Cookies.Add(myCookie)
        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
    End Sub
End Class