
Partial Class _Default
    Inherits Page

    Private Const MAX_WAGES = 99999.99
    Private Const MAX_INTEREST = 1500.0
    '*******************************************************************************************************************
    'ACTION ON "CALCULATE" BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        ' Validate wages and interest earned are below max values
        If Not ValidateLessThanMax(txtWages, "You may not use 1040EZ form if your wages are $100,000 or more.", lblMessage, pnlMessage, MAX_WAGES) Then
            Exit Sub
        End If
        If Not ValidateLessThanMax(txtInterest, "You may not use form 1040EZ if you earned more than $1,500 in taxable interest.", lblMessage, pnlMessage, MAX_INTEREST) Then
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

        End If

        ' Set focus to the wages textbox so user doesn't have to click into it
        If Not IsPostBack() Then
            txtWages.Focus()
        End If
    End Sub
    '*******************************************************************************************************************
    ' Method ErrorMsg
    '   This function displays an error message and chages
    '   the color of the offending text box light red
    ' Returns:
    '   Nothing
    ' Parameters:
    '   textbox As TextBox
    '   message As String
    '   label As Label
    '   panel As Panel
    '*******************************************************************************************************************
    Protected Sub ErrorMsg(textbox As TextBox, message As String, label As Label, panel As Panel)
        label.Text = message
        panel.Attributes.Add("style", "border-style: solid; border-width: thin; margin-top: 10px; padding: 5px; text-align: center; color: white; background-color: red;")
        textbox.Attributes.Add("style", "background-color: #fcbdbd")
        textbox.Focus()
    End Sub
    '*******************************************************************************************************************
    ' Method ResetTextbox
    '   This function sets the background color of a textbox
    '   to white - call this function to reset the color
    '   of a textbox in case it was turned red by an invalid entry
    ' Returns:
    '   Nothing
    ' Parameters:
    '   textbox as TextBox
    '*******************************************************************************************************************
    Protected Sub ResetTextbox(textbox As TextBox)
        textbox.Attributes.Add("style", "background-color: #fff")
    End Sub
    '*******************************************************************************************************************
    ' Function ValidateLessThanMax
    '   This function checks to see if the entered value exceeds the 
    '   maximum allowed amount and if so, calls an error display function.
    '   If the value is valid, the function resets the color of the 
    '   textbox in case it was set to an error color previously.
    ' Returns:
    '   Boolean
    ' Parameters:
    '   textbox As TextBox
    '   message As String
    '   label As Label
    '   panel As Panel
    '   max as Double
    '*******************************************************************************************************************
    Protected Function ValidateLessThanMax(textbox As TextBox, message As String, label As Label, panel As Panel, max As Double) As Boolean
        If CType(textbox.Text, Double) > max Then
            ErrorMsg(textbox, message, label, panel)
            Return False
        Else
            ResetTextbox(textbox)
            Return True
        End If
    End Function
End Class