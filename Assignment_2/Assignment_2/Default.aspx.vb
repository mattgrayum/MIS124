
Partial Class _Default
    Inherits Page

    Protected Sub btnViewTaxReturn_Click(sender As Object, e As EventArgs) Handles btnViewTaxReturn.Click
        Try
            Session("taxPayer") = clsTaxPayerDB.getTaxPayer(lstTaxPayers.SelectedValue)
            Session("taxYear") = txtTaxYear.Text
            Dim taxReturn As clsTaxReturn = clsTaxPayerDB.getTaxReturn(lstTaxPayers.SelectedValue, txtTaxYear.Text)
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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class