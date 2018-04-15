
Partial Class _Default

    Inherits Page

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************

    ' -- Popluates form controls
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        'Render the pop-up message invisible
        noTaxReturnMsg.Visible = False

        'Populate tax year dropdown list
        Using myReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Server.MapPath(path:=".") & "\App_Data\Years.csv")
            myReader.SetDelimiters({","})
            While Not myReader.EndOfData
                lstTaxYear.Items.Add(myReader.ReadFields(0))
            End While
        End Using

        'Set the tax payer and tax year dropdowns to the values that were last chosen during this session
        If Not IsPostBack Then

            If Not Session("taxPayerID") Is Nothing Then

                lstTaxPayers.SelectedValue = Session("taxPayerID")

            End If

            If Not Session("taxYear") Is Nothing Then

                lstTaxYear.SelectedValue = Session("taxYear")

            End If

        End If

    End Sub

    '*******************************************************************************************************************
    'ACTION ON VIEW TAX RETURN BUTTON CLICK
    '*******************************************************************************************************************

    ' -- Uses selected values to set up Tax Payer and Tax Return objects sends user to the Display Tax Return page
    Protected Sub btnViewTaxReturn_Click(sender As Object, e As EventArgs) Handles btnViewTaxReturn.Click

        Try

            'Populate session variables with a tax payer object and the tax year
            Session("taxPayer") = clsTaxPayerDB.getTaxPayer(lstTaxPayers.SelectedValue)
            Session("taxPayerID") = lstTaxPayers.SelectedValue
            Session("taxYear") = lstTaxYear.SelectedValue

            'Attempt to get a tax return for the chosen tax payer and year
            If clsTaxReturnDB.isTaxReturn(lstTaxPayers.SelectedValue, lstTaxYear.SelectedValue) Then
                Session("taxReturn") = clsTaxReturnDB.getTaxReturn(Session("taxPayerID"), Session("taxYear"))

                ' Redirect to the DisplayTaxReturn Page
                Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)
            Else
                Session("taxReturn") = New clsTaxReturn(lstTaxPayers.SelectedValue, lstTaxYear.SelectedValue, False, 0, 0, 0, {"0", "0"}, 0, 0, 0)
                noTaxReturnMsg.Visible = True
            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message
            pnlMessage.Attributes.Add("style", "background:red; color:white; display: block;")
        End Try

    End Sub

    '*******************************************************************************************************************
    'ACTION ON MODAL OK BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnModalOK_Click(sender As Object, e As EventArgs) Handles btnModalOk.Click

        ' Redirect to the DisplayTaxReturn Page
        Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)

    End Sub

    '*******************************************************************************************************************
    'ACTION ON MODAL BACK BUTTON CLICK
    '*******************************************************************************************************************

    ' -- Takes the user 'back' to the home page by hiding the modal window
    Protected Sub btnModalBack_Click(sender As Object, e As EventArgs) Handles btnModalBack.Click

        'Make the modal window disapear
        noTaxReturnMsg.Visible = False

    End Sub

    '*******************************************************************************************************************
    ' Method ValidateStateName
    '   This function checks that an entered State abbreviation is valid
    '   For hooking to a custom validator
    ' Returns:
    '   Nothing
    ' Parameters:
    '   source as Object
    '   args as ServerValidateEventArgs
    '*******************************************************************************************************************
    Sub ValidateStateName(source As Object, args As ServerValidateEventArgs)

        'List of valid States
        Dim validStates() As String = {"AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "HI", "IA",
                                       "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS",
                                       "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA",
                                       "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV", "WY"}

        args.IsValid = False
        If validStates.Contains(args.Value) Then
            args.IsValid = True
        End If

    End Sub

End Class