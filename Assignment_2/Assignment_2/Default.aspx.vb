
Partial Class _Default

    Inherits Page

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************
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
    Protected Sub btnViewTaxReturn_Click(sender As Object, e As EventArgs) Handles btnViewTaxReturn.Click

        Try

            'Populate session variables with a tax payer object and the tax year
            Session("taxPayer") = clsTaxPayerDB.getTaxPayer(lstTaxPayers.SelectedValue)
            Session("taxPayerID") = lstTaxPayers.SelectedValue
            Session("taxYear") = lstTaxYear.SelectedValue

            'Attempt to get a tax return for the chosen tax payer and year
            If clsTaxPayerDB.isTaxReturn(lstTaxPayers.SelectedValue, lstTaxYear.SelectedValue) Then
                Session("taxReturn") = clsTaxPayerDB.getTaxReturn(Session("taxPayerID"), Session("taxYear"))

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
    Protected Sub btnModalBack_Click(sender As Object, e As EventArgs) Handles btnModalBack.Click
        'Make the modal window disapear
        noTaxReturnMsg.Visible = False
    End Sub
End Class