
Partial Class _Default
    Inherits Page

    Protected Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Server.Transfer("Default.aspx")
    End Sub
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load
        Dim dblWages As Double = Session("wages")
        'Dim dblTaxableInterest As Double = Session("interest")
        'Dim dblUnemploymentCompensation As Double = Session("unemployment")
        'Dim dblIncomeTaxWithheld As Double = Session("withholding")
        'Dim dblEIC As Double = Session("eic")
        'Dim dblCompatPay As Double = Session("nontaxable")
        'Dim intNumberOfTaxpayers As Integer =
        'Dim trsx As clsTaxRates = New clsTaxRates("C:\Users\Matthew Grayum\source\repos\MIS124\Assignment_1\Assignment_1\")
        'Dim taxReturn As clsTaxReturn = New clsTaxReturn()
        txtWagesResult.Text = Session("wages")
        txtInterestResult.Text = Session("interest")
        txtUnemploymentResult.Text = Session("unemployment")
        Dim numberExceptions As Integer = 0
        If (Session("you") = True) Then
            numberExceptions = numberExceptions + 1
        End If
        If (Session("spouse") = True) Then
            numberExceptions = numberExceptions + 1
        End If

        txtWithholdingResult.Text = numberExceptions
        txtNontaxableResult.Text = Session("nontaxable")
        txtEarnedIncomeResult.Text = Session("eic")
        If (numberExceptions > 0) Then
            lblSuccessMessage.Text = "WoooooHoooooo!"
        End If


    End Sub
End Class