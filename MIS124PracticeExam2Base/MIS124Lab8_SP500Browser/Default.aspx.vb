Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Write the implementation below
        Dim myProduct As clsProduct = clsProductDB.getProduct(Int(txtProductID.Text))
        txtProductName.Text = myProduct.ProductName
        txtUnitsInStock.Text = myProduct.UnitsInStock
        txtRetailPrice.Text = myProduct.RetailPrice
        chkDiscontinued.Checked = False
        If myProduct.Discontinued = "YES" Then
            chkDiscontinued.Checked = True
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Write the implementation below

    End Sub
End Class