Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lblMessages.Text = ""
    End Sub

    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Write the implementation below
        lblMessages.Text = ""
        Try
            Dim myProduct As clsProduct = clsProductDB.getProduct(Int(txtProductID.Text))
            txtProductName.Text = myProduct.ProductName
            txtUnitsInStock.Text = myProduct.UnitsInStock
            txtRetailPrice.Text = FormatCurrency(myProduct.RetailPrice, 2)
            chkDiscontinued.Enabled = True
            chkDiscontinued.Checked = False
            If myProduct.Discontinued = "YES" Then
                chkDiscontinued.Checked = True
            End If
        Catch ex As Exception
            lblMessages.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Write the implementation below
        Try
            Dim updatedRows = clsProductDB.updateProduct(Int(txtProductID.Text), CType(txtRetailPrice.Text, Decimal))
            If updatedRows > 0 Then
                lblMessages.Text = "The Database has been successfully updated."
            End If
        Catch ex As Exception
            lblMessages.Text = ex.Message
        End Try

    End Sub
End Class