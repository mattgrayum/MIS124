
Partial Class _Default

    Inherits Page

    '*******************************************************************************************************************
    'ACTION ON PAGE LOAD
    '*******************************************************************************************************************
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Load

        Using myReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Server.MapPath(path:=".") & "\App_Data\Years.csv")
            myReader.SetDelimiters({","})
            While Not myReader.EndOfData
                lstTaxYear.Items.Add(myReader.ReadFields(0))
            End While
        End Using



        'Populate the tax payer dropdown and tax year with values that were last chosen during this session
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
            Else
                Session("taxReturn") = New clsTaxReturn(lstTaxPayers.SelectedValue, lstTaxYear.SelectedValue, False, 0, 0, 0, {"0", "0"}, 0, 0, 0)
                MsgBox("Tax Return not found. I will take you to the Tax Return form so you can add a new tax return.")
            End If
            'Present the user with a notice if there is no tax return for the chosen
            'tax payer and tax year - otherwise put the tax return object into a session variable
            'If taxReturn Is Nothing Then
            '    MsgBox("Tax Return not found. I will take you to the Tax Return form so you can add a new tax return.")
            'Else
            '    Session("taxReturn") = taxReturn
            'End If

            ' Redirect to the DisplayTaxReturn Page
            Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)

        Catch ex As Exception
            lblMessage.Text = ex.Message
            pnlMessage.Attributes.Add("style", "background:red; color:white; display: block;")
        End Try

    End Sub

End Class