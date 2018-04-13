
Partial Class _Default

    Inherits Page

    '*******************************************************************************************************************
    'ACTION ON VIEW TAX RETURN BUTTON CLICK
    '*******************************************************************************************************************
    Protected Sub btnViewTaxReturn_Click(sender As Object, e As EventArgs) Handles btnViewTaxReturn.Click

        Try
            'Populate session variables with a tax payer object and the tax year
            Session("taxPayer") = clsTaxPayerDB.getTaxPayer(lstTaxPayers.SelectedValue)
            Session("taxYear") = txtTaxYear.Text

            'Attempt to get a tax return for the chosen tax payer and year
            Dim taxReturn As clsTaxReturn = clsTaxPayerDB.getTaxReturn(lstTaxPayers.SelectedValue, txtTaxYear.Text)

            'Present the user with a notice if there is no tax return for the chosen
            'tax payer and tax year - otherwise put the tax return object into a session variable
            If taxReturn Is Nothing Then
                MsgBox("Tax Return not found. I will take you to the Tax Return form so you can add a new tax return.")
            Else
                Session("taxReturn") = taxReturn
            End If

            ' Redirect to the DisplayTaxReturn Page
            Response.Redirect(url:="~/DisplayTaxReturn.aspx", endResponse:=False)

        Catch ex As Exception
            lblMessage.Text = ex.Message
            pnlMessage.Attributes.Add("style", "background:red; color:white; display: block;")
        End Try

    End Sub

End Class